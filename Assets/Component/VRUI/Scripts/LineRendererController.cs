﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour {

    SteamVR_ControllerManager player;
    [SerializeField]
    GameObject Pointer; //移動位置のTarget
    [SerializeField]
    float GroundAngle = 30.0f; //角度

    [SerializeField]
    float initialVelocity = 10.0f; //力
    [SerializeField]
    float timeResolution = 0.02f;  //点と点の距離
    [SerializeField]
    float MaxTime = 10.0f;  //線の長さ
    [SerializeField]
    int RelayPoint = 15; //中継点
    [SerializeField]
    float Curvature = 0.9f; //キャンバ
    [SerializeField]
    float Delay = 1.0f;

    [SerializeField]
    Vector3 PositionDiff;
    [SerializeField]
    LayerMask layerMask = -1;

    float DelTime = 0.0f;

    GameObject GetControllerRotation;

    bool Move = false;
    bool Projectile_judge = false; //放物線判断
    bool TargetSetActive = false;
    bool GroundAngle_judge = false; //地形角度の判断
    bool havePointer = false;
    bool isWarpInput = false;

    Vector3 Point;
    Vector3 GetPosition;

    private GameObject PointerInstance;
    private LineRenderer lineRenderer;
    private SteamVR_TrackedObject TrackedObject;

    public Vector3 TargetPoint { get { return Point; } }
    public bool IsWarpInput { get { return isWarpInput; } }


    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        player = GameObject.FindObjectOfType<SteamVR_ControllerManager>( );
        TrackedObject = player.right.GetComponent<SteamVR_TrackedObject>( );
        GetControllerRotation = GameObject.Find( "Controller (right)" );
    }

    void Update() {
        //update毎にリセットする物はここに書く
        ResetState();
        Quaternion ControllerRotation = GetControllerRotation.transform.rotation;


        Vector3 postion = (PositionDiff.magnitude * TrackedObject.transform.forward.normalized ) + TrackedObject.transform.position;

        //VRコントローラの処理
        var device = SteamVR_Controller.Input((int)TrackedObject.index);

        //放物線とTargetの処理
        int index = 0;

        Vector3 velocityVector = TrackedObject.transform.forward * initialVelocity;
        Vector3 currentPosition = postion;

        if (!havePointer) {
            PointerInstance = Instantiate( Pointer, Point, Quaternion.identity);
            havePointer = true;
        }

        PointerInstance.transform.position = Point;

        lineRenderer.positionCount = (int)(MaxTime / timeResolution);

        currentPosition.y = postion.y - 0.01f;

        //ControllerVariables.Normalize();

        for ( float t = 0.0f; t < MaxTime; t += timeResolution ) {

            if ( index < lineRenderer.positionCount ) {
                lineRenderer.SetPosition( index, currentPosition );
            }

            RaycastHit hit;

            if ( Physics.Raycast( currentPosition, velocityVector, out hit, velocityVector.magnitude * timeResolution, layerMask ) ) {

                lineRenderer.positionCount = index + 2;

                lineRenderer.SetPosition( index + 1, hit.point );

                
                //VRコントローラの処理
                if ( device.GetTouchDown( SteamVR_Controller.ButtonMask.Trigger ) && Projectile_judge == false ) {
                    GetPosition = hit.point;
                    TimeDel( );
                }

                //角度の判断
                PointerInstance.transform.rotation = Quaternion.LookRotation( hit.normal );
                if ( Vector3.Angle( hit.normal, Vector3.up ) >= GroundAngle ) {
                    GroundAngle_judge = true;
                } else {
                    GroundAngle_judge = false;
                }

                Point = hit.point;
                Point.y = hit.point.y + 0.05f;

                TargetSetActive = false;
                break;

            } else {
                TargetSetActive = true;
            }

            //キャンバシミュレーション
            currentPosition += velocityVector * timeResolution;
            
            velocityVector += ControllerRotation * Physics.gravity * timeResolution;

            if ( index >= RelayPoint ) {
                velocityVector *= Curvature;
            }
            index++;
            if ( index >= lineRenderer.positionCount ) {
                index -= 2;
            }

        }

        if ( Move ) {
            DelTime += Time.deltaTime;

            if ( DelTime >= Delay ) {
                player.transform.position = GetPosition;
                isWarpInput = true;
                DelTime = 0.0f;
                Move = false;
            }
        }
        //Targetの判断
        Projectile_judge = ColliderTag(Point);

    }

    private void TimeDel( ) {
            Move = true;
    }

    private void ResetState( ) {
        isWarpInput = false;
    }

    private bool ColliderTag(Vector3 point) {
        Ray ray = new Ray(point, Vector3.down);
        RaycastHit hit2;
        if (Physics.Raycast(ray, out hit2)) {
            if (hit2.distance > 1f || TargetSetActive == true || GroundAngle_judge == true) {
                PointerInstance.SetActive(false);
                return true;
            } else {
                PointerInstance.SetActive(true);
                return false;
            }
        }
        return false;
    }

    public void DeleteLine() {
        if ( lineRenderer ) {
            lineRenderer.positionCount = 0;
        }
    }

    public void DeleteTarget() {
        Destroy(PointerInstance);
    }

}

/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

//Not extending EventMediator anymore
public class BallMediator : Mediator
{
    [Inject]
    public BallView view { get; set; }

    [Inject]
    public NotifyBallClickedSignal ballClicked { get; set; }

    [Inject]
    public RequestBallCreationSignal createBall { get; set; }

    //[Inject]
    //public IMouseModel model { get; set; }

    public override void OnRegister()
    {
        view.collisionSignal.AddListener(onViewCollision);

        view.clickSignal.AddListener(onViewClicked);

        view.dragSignal.AddListener(onViewDragged);

        view.releaseSignal.AddListener(onViewReleased);

        view.init();
    }

    public override void OnRemove()
    {
        Debug.Log("BallMediator : OnRemove");

        view.clickSignal.RemoveListener(onViewClicked);

        view.dragSignal.RemoveListener(onViewDragged);

        view.releaseSignal.RemoveListener(onViewReleased);
    }

    private void onViewCollision(Collision2D coll)
    {
        Debug.Log("BallMediator : onViewCollision");
        Debug.Log("coll.transform : " + coll.transform);
        String collName = coll.gameObject.name;
        Debug.Log(collName + " Collision");
        if (collName.Contains("Wall"))
        {
            Debug.Log("Collided with a wall");
        }
        else if (collName.Contains("Circle"))
        {
            Debug.Log("Collided with a ball");
            if(view.rigidbody2D.mass == coll.rigidbody.mass)
            {
                float m1 = view.rigidbody2D.mass;
                Vector2 v1 = view.rigidbody2D.velocity;
                float m2 = coll.rigidbody.mass;
                Vector2 v2 = coll.rigidbody.velocity;
                float M = m1 + m2;
                
                float area = M;
                Debug.Log(M);

                float r = (float)Math.Sqrt(area / Math.PI);

                view.transform.localScale = Vector2.one * r;
                
                Debug.Log(v1);
                Debug.Log(v2);
                Vector2 vf = coll.relativeVelocity / 2 / Time.fixedDeltaTime;
                Debug.Log(vf);
                view.rigidbody2D.AddForce(M*vf, ForceMode2D.Force);


                view.rigidbody2D.mass = M;

                view.transform.position = (view.transform.position + coll.transform.position) / 2;
                GameObject.Destroy(coll.gameObject);
            }
            else if (   view.rigidbody2D.mass * 2 == coll.rigidbody.mass ||
                        view.rigidbody2D.mass == coll.rigidbody.mass * 2)
            {

            }
            else
            {
                Vector2 pos = coll.transform.position;
                float r = (float)Math.Sqrt(coll.rigidbody.mass / Math.PI);
                Vector2 vel = coll.relativeVelocity / Time.fixedDeltaTime;
                Vector2 inverse = new Vector2(-vel.y, vel.x);

                createBall.Dispatch(pos + new Vector2(r, 0), vel/2);
                createBall.Dispatch(pos + new Vector2(-r, 0), vel/-2);
                createBall.Dispatch(pos + new Vector2(0, r), inverse/2);
                createBall.Dispatch(pos + new Vector2(0, -r), inverse / -2);

                GameObject.Destroy(coll.gameObject);
                GameObject.Destroy(view.gameObject);

            }
        }
        else
        {
            Debug.Log("Something else?");
        }
        AudioSource sound = view.GetComponent<AudioSource>();
        sound.Play();
        Debug.Log("coll.relativeVelocity : " + coll.relativeVelocity);
        

    }

    private void onViewClicked()
    {
        Debug.Log("BallMediator : View click detected");

        ballClicked.Dispatch(true);
        //Vector3 pos = Input.mousePosition;
        //pos = Camera.main.ScreenToWorldPoint(pos);
        //pos.z = 0;
        //view.transform.position = pos;
        //Dispatch a Signal. We're adding a string value (different from MyFirstContext,
        //just to show how we can Inject values into commands)
    }

    private void onViewDragged()
    {
        Debug.Log("BallMediator : View dragged detected");
        view.lastPosition = view.transform.position;

        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = 0;
        view.transform.position = pos;

        view.velocity = Vector3.zero;
        //Dispatch a Signal. We're adding a string value (different from MyFirstContext,
        //just to show how we can Inject values into commands)
    }

    private void onViewReleased()
    {
        Debug.Log("BallMediator : View released detected");
        //view.velocity = view.transform.position - view.lastPosition;
        Debug.Log(view.rigidbody2D);
        var multiplier = 10;
        Vector2 force = view.rigidbody2D.mass * (view.transform.position - view.lastPosition) * multiplier / Time.fixedDeltaTime;
        Debug.Log(force);
        view.rigidbody2D.velocity = Vector2.zero;
        view.rigidbody2D.AddForce(force, ForceMode2D.Force);
        
        ballClicked.Dispatch(false);
    }
}


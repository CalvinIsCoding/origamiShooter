using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamNumbersTogether : MonoBehaviour
{
    public Transform centerOfSlam;
    public Transform rightElement;
    public Transform leftElement;
    public Vector3 originalRightElementPosition;
    public Vector3 originalLeftElementPosition;
    public int originalRightElementSize;
    public int originalLeftElementSize;
    public Vector3 originalCenterElementSize;
    //public Vector3 zeroVector;
    private int totalFrames;
    

    public Timers timers;
    void Start()
    {
        totalFrames = 15;
       // zeroVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator CrunchNumbers()
    {
        originalRightElementPosition = rightElement.localPosition;
        originalLeftElementPosition = leftElement.localPosition;
        originalCenterElementSize = centerOfSlam.localScale;
        for (int i = 0; i < totalFrames; i++)
        {
            rightElement.localPosition = rightElement.localPosition + ((Vector3.zero - originalRightElementPosition) /(totalFrames));
            leftElement.localPosition = leftElement.localPosition + ((Vector3.zero - originalLeftElementPosition) / (totalFrames));
            //rightElement.localScale = rightElement.localScale - (rightElement.localScale / totalFrames);
            //leftElement.localScale = leftElement.localScale - (leftElement.localScale / totalFrames);
            centerOfSlam.localScale = centerOfSlam.localScale - (originalCenterElementSize / totalFrames);
            yield return new WaitForSeconds(timers.numbersSlammingTogetherTime/totalFrames);
        }
        StartCoroutine(ReturnNumbersToNormalSize());
        
        //rightElement.localScale = 
       // left

    }
    public IEnumerator ReturnNumbersToNormalSize()
    {
        yield return new WaitForSeconds(timers.lullAfterFireModeEndsButWaveHasntBegun - timers.numbersSlammingTogetherTime );
        rightElement.localPosition = originalRightElementPosition;
        leftElement.localPosition = originalLeftElementPosition;
        centerOfSlam.localScale = originalCenterElementSize;
    }
}

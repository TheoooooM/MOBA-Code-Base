using UnityEngine;

public  class GlobalDelegates : MonoBehaviour
{
    public delegate void NoParameterDelegate();
    public delegate void BoolDelegate(bool b);

    public delegate void ByteDelegate(bool b);

    public delegate void IntDelegate(int u);

    public delegate void FloatDelegate(float f);

    public delegate void Vector3Delegate(Vector3 v);

    public delegate void ByteIntArrayVector3ArrayDelegate(byte b, int[] uintArray, Vector3[] vector3s);
    
}

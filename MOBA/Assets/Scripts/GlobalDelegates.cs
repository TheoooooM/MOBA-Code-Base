using UnityEngine;

public  class GlobalDelegates : MonoBehaviour
{
    public delegate void NoParameterDelegate();
    public delegate void BoolDelegate(bool b);

    public delegate void ByteDelegate(bool b);

    public delegate void UintDelegate(uint u);

    public delegate void FloatDelegate(float f);

    public delegate void Vector3Delegate(Vector3 v);

    public delegate void ByteUintArrayVector3ArrayDelegate(byte b, uint[] uintArray, Vector3[] vector3s);
    
}

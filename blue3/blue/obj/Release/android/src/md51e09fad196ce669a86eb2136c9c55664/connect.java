package md51e09fad196ce669a86eb2136c9c55664;


public class connect
	extends java.lang.Thread
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("blue.connect, blue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", connect.class, __md_methods);
	}


	public connect () throws java.lang.Throwable
	{
		super ();
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, blue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public connect (android.bluetooth.BluetoothDevice p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, blue, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Bluetooth.BluetoothDevice, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
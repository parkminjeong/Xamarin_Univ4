package md515b436a7791fa645b544f0093f1d0502;


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
		mono.android.Runtime.register ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", connect.class, __md_methods);
	}


	public connect () throws java.lang.Throwable
	{
		super ();
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public connect (java.lang.Runnable p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public connect (java.lang.Runnable p0, java.lang.String p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public connect (java.lang.String p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public connect (java.lang.ThreadGroup p0, java.lang.Runnable p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public connect (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public connect (java.lang.ThreadGroup p0, java.lang.Runnable p1, java.lang.String p2, long p3) throws java.lang.Throwable
	{
		super (p0, p1, p2, p3);
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Java.Lang.IRunnable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int64, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public connect (java.lang.ThreadGroup p0, java.lang.String p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Java.Lang.ThreadGroup, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}

	public connect (android.bluetooth.BluetoothDevice p0) throws java.lang.Throwable
	{
		super ();
		if (getClass () == connect.class)
			mono.android.TypeManager.Activate ("blue.connect, huhu00, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Bluetooth.BluetoothDevice, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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

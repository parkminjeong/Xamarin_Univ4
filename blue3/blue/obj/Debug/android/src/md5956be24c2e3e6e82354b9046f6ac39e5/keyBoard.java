package md5956be24c2e3e6e82354b9046f6ac39e5;


public class keyBoard
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("blue.keyBoard, huhu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", keyBoard.class, __md_methods);
	}


	public keyBoard () throws java.lang.Throwable
	{
		super ();
		if (getClass () == keyBoard.class)
			mono.android.TypeManager.Activate ("blue.keyBoard, huhu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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

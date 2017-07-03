package md509cdedaf37a050bb3470b00467e488d9;


public class PullToRefreshLayoutRenderer
	extends android.support.v4.widget.SwipeRefreshLayout
	implements
		mono.android.IGCUserPeer,
		android.support.v4.widget.SwipeRefreshLayout.OnRefreshListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_isRefreshing:()Z:GetIsRefreshingHandler\n" +
			"n_setRefreshing:(Z)V:GetSetRefreshing_ZHandler\n" +
			"n_canChildScrollUp:()Z:GetCanChildScrollUpHandler\n" +
			"n_onRefresh:()V:GetOnRefreshHandler:Android.Support.V4.Widget.SwipeRefreshLayout/IOnRefreshListenerInvoker, Xamarin.Android.Support.Core.UI\n" +
			"";
		mono.android.Runtime.register ("Refractored.XamForms.PullToRefresh.Droid.PullToRefreshLayoutRenderer, Refractored.XamForms.PullToRefresh.Droid, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null", PullToRefreshLayoutRenderer.class, __md_methods);
	}


	public PullToRefreshLayoutRenderer (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == PullToRefreshLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Refractored.XamForms.PullToRefresh.Droid.PullToRefreshLayoutRenderer, Refractored.XamForms.PullToRefresh.Droid, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public PullToRefreshLayoutRenderer (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == PullToRefreshLayoutRenderer.class)
			mono.android.TypeManager.Activate ("Refractored.XamForms.PullToRefresh.Droid.PullToRefreshLayoutRenderer, Refractored.XamForms.PullToRefresh.Droid, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean isRefreshing ()
	{
		return n_isRefreshing ();
	}

	private native boolean n_isRefreshing ();


	public void setRefreshing (boolean p0)
	{
		n_setRefreshing (p0);
	}

	private native void n_setRefreshing (boolean p0);


	public boolean canChildScrollUp ()
	{
		return n_canChildScrollUp ();
	}

	private native boolean n_canChildScrollUp ();


	public void onRefresh ()
	{
		n_onRefresh ();
	}

	private native void n_onRefresh ();

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

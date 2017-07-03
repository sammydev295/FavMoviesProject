package md5a85691cbb9292fe49618c3c471a92955;


public class TapEffect_RippleDrawable
	extends android.support.v7.graphics.drawable.DrawableWrapper
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getOpacity:()I:GetGetOpacityHandler\n" +
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"n_setAlpha:(I)V:GetSetAlpha_IHandler\n" +
			"n_setColorFilter:(Landroid/graphics/ColorFilter;)V:GetSetColorFilter_Landroid_graphics_ColorFilter_Handler\n" +
			"";
		mono.android.Runtime.register ("AsNum.XFControls.Droid.Effects.TapEffect+RippleDrawable, AsNum.XFControls.Droid, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null", TapEffect_RippleDrawable.class, __md_methods);
	}


	public TapEffect_RippleDrawable (android.graphics.drawable.Drawable p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == TapEffect_RippleDrawable.class)
			mono.android.TypeManager.Activate ("AsNum.XFControls.Droid.Effects.TapEffect+RippleDrawable, AsNum.XFControls.Droid, Version=1.0.0.6, Culture=neutral, PublicKeyToken=null", "Android.Graphics.Drawables.Drawable, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public int getOpacity ()
	{
		return n_getOpacity ();
	}

	private native int n_getOpacity ();


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);


	public void setAlpha (int p0)
	{
		n_setAlpha (p0);
	}

	private native void n_setAlpha (int p0);


	public void setColorFilter (android.graphics.ColorFilter p0)
	{
		n_setColorFilter (p0);
	}

	private native void n_setColorFilter (android.graphics.ColorFilter p0);

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

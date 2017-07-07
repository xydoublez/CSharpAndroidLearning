using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;

namespace HelloWorld
{
    [Activity(Label = "HelloWorld", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
            SetContentView(Resource.Layout.Main);
            
            var button = FindViewById<Button>(Resource.Id.btnOk);
            button.Click += delegate
            {
                button.Text = string.Format("这是第{0} 单击!", count++);
            };
            var btnBrowser = FindViewById<Button>(Resource.Id.btnBrowser);
            btnBrowser.Click += BtnBrowser_Click;
            //获取WebView对象
            var webView = FindViewById<WebView>(Resource.Id.webView1);
            //申明WebView的配置
            WebSettings settings = webView.Settings;
            //设置允许执行JS
            settings.JavaScriptEnabled = true;
            //设置可以通过JS打开窗口
            settings.JavaScriptCanOpenWindowsAutomatically = true;
            //这里是自己创建的WebView客户端类
            var webc = new MyCommWebClient();
            //设置自己的WebView客户端
            webView.SetWebViewClient(webc);
        }
        class MyCommWebClient : WebViewClient
        {
            //重写页面加载的方法
            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                //使用本控件加载
                view.LoadUrl(url);
                //并返回true
                return true;
            }
        }
        private void BtnBrowser_Click(object sender, System.EventArgs e)
        {
            
            var webView = FindViewById<WebView>(Resource.Id.webView1);
            var url = FindViewById<EditText>(Resource.Id.txtUrl).Text;
            webView.LoadUrl(url);
            Toast.MakeText(this.BaseContext, "成功加载网页", ToastLength.Long).Show();
        }
    }
}


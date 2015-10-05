using UnityEngine;
using System.Collections;
using Soomla.Profile;
using System.IO;

namespace HappyApp
{
	[Prefab("UIManager", true)]
	public class UIManager : Singleton<UIManager>
    {
        public View_Quote m_quoteView;
		public View_TopButtons m_topButtonsView;
		public Stack m_viewStack;

		private string m_screenToSharePath;

		void Start()
        {
            HideAllViews(false);
            m_quoteView.Show(true, 1f);
        }

        public void HideAllViews(bool _animated = true)
        {
            m_quoteView.Hide(_animated);
			m_topButtonsView.Hide(_animated);
        }

		public void FacebookLoginPressed()
		{
			SoomlaProfile.Login(Provider.FACEBOOK);
		}

		public void FacebookLogoutPressed()
		{
			SoomlaProfile.Logout(Provider.FACEBOOK);
		}

		public void SharePressed()
		{
			string screenshotPath = "";
            TakeScreenshotAndSave("screenshot.jpg", out screenshotPath);
			
			SoomlaProfile.MultiShare("I love this quote", screenshotPath);
		}

		public byte[] TakeScreenshot()
		{
			var width = Screen.width;
			var height = Screen.height;
			var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
			tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
			tex.Apply();

			return tex.EncodeToPNG();
		}

		public void TakeScreenshotAndSave(string fileName, out string finalPath)
		{
			byte[] bytes = TakeScreenshot();
			SaveScreenshot(bytes, fileName, out finalPath);
		}

		public void SaveScreenshot(byte[] textureBytes, string filename, out string _path)
		{
			string fullPath = Application.persistentDataPath + "/" + filename;
            File.WriteAllBytes(fullPath, textureBytes);
			_path = fullPath;
		}

		public void RefreshQuotePressed()
		{
			HideAllViews(false);
			m_quoteView.SetNewQuote();
			m_quoteView.Show(true, 0.1f);
		}
    }
}
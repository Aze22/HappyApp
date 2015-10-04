using UnityEngine;
using System.Collections;
using Soomla.Profile;

namespace HappyApp
{
    public class UIManager : MonoBehaviour
    {
        public View_Quote m_quoteView;
        public Stack m_viewStack;

        void Start()
        {
            HideAllViews(false);
            m_quoteView.Show(true, 1f);
        }

        public void HideAllViews(bool _animated = true)
        {
            m_quoteView.Hide(_animated);
        }

		public void FacebookLoginPressed()
		{
			SoomlaProfile.Login(Provider.FACEBOOK);
		}
    }
}
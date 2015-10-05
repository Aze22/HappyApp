using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Google2u;
using UnityEngine.Events;

namespace HappyApp
{
    public class View_Quote : View
    {
        [HideInInspector]
        public Text m_quoteText;
        [HideInInspector]
        public Text m_authorText;
        [HideInInspector]
        public Text m_bookText;

        public float m_authorDelay;
        public float m_bookDelay;

        [HideInInspector]
        public QuotesRow m_currentQuote;
		private IEnumerator m_currentShowQuoteRoutine = null;

        // Use this for initialization
        void Start()
        {
			SetNewQuote();
        }

		public void SetNewQuote()
		{
			m_currentQuote = Quotes.Instance.GetRow((Quotes.rowIds) Random.Range(0, Quotes.Instance.Rows.Count));

			m_quoteText.text = string.Concat("'", m_currentQuote._Quote, "'");
			m_authorText.text = string.Concat("- ", m_currentQuote._Author);
			m_bookText.text = m_currentQuote._Book;
		}

        public override void Show(bool _animated = true, float _delay = 0, UnityAction _OnShowFinished = null)
        {
			m_authorText.rectTransform.localScale = Utils.zeroUI;
			m_bookText.rectTransform.localScale = Utils.zeroUI;

			base.Show(_animated, _delay, _OnShowFinished);

			if (m_currentShowQuoteRoutine != null)
				StopCoroutine(m_currentShowQuoteRoutine);

			m_currentShowQuoteRoutine = ShowQuoteRoutine(_animated, _delay, _OnShowFinished);
			StartCoroutine(m_currentShowQuoteRoutine);
        }

		public override void Hide(bool _animated = true, float _delay = 0, UnityAction _OnHideFinished = null)
		{
			if (m_currentShowQuoteRoutine != null)
				StopCoroutine(m_currentShowQuoteRoutine);

			base.Hide(_animated, _delay, _OnHideFinished);
			
			m_authorText.rectTransform.localScale = Utils.zeroUI;
			m_bookText.rectTransform.localScale = Utils.zeroUI;
			m_bookText.GetComponent<Animator>().enabled = false;
			m_authorText.GetComponent<Animator>().enabled = false;
		}

		private IEnumerator ShowQuoteRoutine(bool _animated = true, float _delay = 0f, UnityAction _OnShowFinished = null)
        {
            yield return new WaitForSeconds(_delay);

            if (_animated)
            {
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + m_authorDelay);
				m_authorText.GetComponent<Animator>().enabled = true;

				if (!string.IsNullOrEmpty(m_bookText.text))
				{
					yield return new WaitForSeconds(m_bookDelay);
					m_bookText.GetComponent<Animator>().enabled = true;
				}

				UIManager.GetInstance().m_topButtonsView.Show(true, 1f);
			}

			m_currentShowQuoteRoutine = null;
        }
    }
}
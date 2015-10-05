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
        

        // Use this for initialization
        void Start()
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

            StartCoroutine(ShowQuoteRoutine(_animated, _delay, _OnShowFinished));
        }

        private IEnumerator ShowQuoteRoutine(bool _animated = true, float _delay = 0f, UnityAction _OnShowFinished = null)
        {
            yield return new WaitForSeconds(_delay);

            if (_animated)
            {
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length + m_authorDelay);
				m_authorText.GetComponent<Animator>().enabled = true;

                yield return new WaitForSeconds(m_bookDelay);
				m_bookText.GetComponent<Animator>().enabled = true;
			}
        }

    }
}
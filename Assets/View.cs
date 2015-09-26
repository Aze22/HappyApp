using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace HappyApp
{
    public class View : MonoBehaviour
    {
        [HideInInspector]
        public UnityEvent OnShowFinishedEvent;
        [HideInInspector]
        public UnityEvent OnHideFinishedEvent;
        [HideInInspector]
        public Animator animator;
        [HideInInspector]
        public RectTransform rectTransform;
        [HideInInspector]
        public GameObject m_container;

        public virtual void Awake()
        {
            AwakeInit();
        }

        public virtual void AwakeInit()
        {
            rectTransform = GetComponent<RectTransform>();
            animator = GetComponent<Animator>();
            m_container = transform.GetChild(0).gameObject;
        }

        public virtual void Start()
        {
            StartInit();
        }

        public virtual void StartInit()
        {
            OnShowFinishedEvent = new UnityEvent();
            OnHideFinishedEvent = new UnityEvent();
        }

        public virtual void Show(bool _animated = true, float _delay = 0f, UnityAction _OnShowFinished = null) { StartCoroutine(ShowRoutine(_animated, _delay, _OnShowFinished)); }

        private IEnumerator ShowRoutine(bool _animated = true, float _delay = 0f, UnityAction _OnShowFinished = null)
        {
            OnShowFinishedEvent.AddListener(OnShowFinished);
            OnShowFinishedEvent.SafeAddListener(_OnShowFinished);

            yield return new WaitForSeconds(_delay);

            m_container.gameObject.SetActive(true);

            if (_animated)
            {
                animator.enabled = true;
                yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            }
            
            OnShowFinishedEvent.SafeInvoke();
        }

        public virtual void OnShowFinished()
        {

        }

        public virtual void Hide(bool _animated = true, float _delay = 0, UnityAction _OnHideFinished = null)
        {
            OnHideFinishedEvent.AddListener(OnHideFinished);
            OnHideFinishedEvent.SafeAddListener(_OnHideFinished);
            OnHideFinishedEvent.SafeInvoke();
        }

        public virtual void OnHideFinished()
        {
            m_container.gameObject.SetActive(false);
        }
    }
}
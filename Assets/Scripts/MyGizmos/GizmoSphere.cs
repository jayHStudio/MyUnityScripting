// JayH
// 구체의 기즈모를 그린다. 그리고 방향을 시각적으로 표시하기 위해 오브젝트의 앞쪽에 가시선 벡터를 그린다.


using UnityEngine;

namespace JayH
{

    public class GizmoSphere : MonoBehaviour
    {
        // 디버깅 정보 표출 여부
        public bool bDrawGizmos = true;

        // 기즈모를 그리도록 호출한다. 이 이벤트를 이용하면 항상 그리게 된다.
        // 선택된 오브젝트에만 기즈모를 그리도록 하려면 OnDrawGizmosSelected를 이용한다.
        private void OnDrawGizmos()
        {
            if ( !bDrawGizmos )
            {
                return;
            }

            // 기즈모의 색상 설정
            Gizmos.color = Color.blue;

            // 전면 벡터를 그려 오브젝트가 향하는 방향을 보여준다.
            Gizmos.DrawRay(this.transform.position, this.transform.forward.normalized * 4.0f);

            // 기즈모의 색상 설정
            Gizmos.color = Color.red;

            // 해당 오브젝트의 반경을 보여준다.
            Gizmos.DrawWireSphere(this.transform.position, 4.0f);

            // 색상을 다시 흰색으로 되돌린다.
            Gizmos.color = Color.white;
        }
    }

}

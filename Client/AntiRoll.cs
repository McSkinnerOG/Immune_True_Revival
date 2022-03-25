using UnityEngine;

public class AntiRoll : MonoBehaviour
{
	public WheelCollider m_wheelFL;

	public WheelCollider m_wheelFR;

	public WheelCollider m_wheelRL;

	public WheelCollider m_wheelRR;

	public float m_antiRoll = 1f;

	private void FixedUpdate()
	{
		WheelHit hit = default(WheelHit);
		float num = 1f;
		float num2 = 1f;
		float num3 = 1f;
		float num4 = 1f;
		bool groundHit = m_wheelFL.GetGroundHit(out hit);
		if (groundHit)
		{
			num = (0f - m_wheelFL.transform.InverseTransformPoint(hit.point).y - m_wheelFL.radius) / m_wheelFL.suspensionDistance;
		}
		bool groundHit2 = m_wheelFR.GetGroundHit(out hit);
		if (groundHit2)
		{
			num2 = (0f - m_wheelFR.transform.InverseTransformPoint(hit.point).y - m_wheelFR.radius) / m_wheelFR.suspensionDistance;
		}
		bool groundHit3 = m_wheelRL.GetGroundHit(out hit);
		if (groundHit3)
		{
			num3 = (0f - m_wheelRL.transform.InverseTransformPoint(hit.point).y - m_wheelRL.radius) / m_wheelRL.suspensionDistance;
		}
		bool groundHit4 = m_wheelRR.GetGroundHit(out hit);
		if (groundHit4)
		{
			num4 = (0f - m_wheelRR.transform.InverseTransformPoint(hit.point).y - m_wheelRR.radius) / m_wheelRR.suspensionDistance;
		}
		float num5 = (num - num2) * m_wheelFL.suspensionSpring.spring * m_antiRoll;
		float num6 = (num3 - num4) * m_wheelRL.suspensionSpring.spring * m_antiRoll;
		if (groundHit)
		{
			base.rigidbody.AddForceAtPosition(m_wheelFL.transform.up * (0f - num5), m_wheelFL.transform.position);
		}
		if (groundHit2)
		{
			base.rigidbody.AddForceAtPosition(m_wheelFR.transform.up * num5, m_wheelFR.transform.position);
		}
		if (groundHit3)
		{
			base.rigidbody.AddForceAtPosition(m_wheelRL.transform.up * (0f - num6), m_wheelRL.transform.position);
		}
		if (groundHit4)
		{
			base.rigidbody.AddForceAtPosition(m_wheelRR.transform.up * num6, m_wheelRR.transform.position);
		}
	}
}

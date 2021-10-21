using UnityEngine;

public class ColorCheckPoint : Colored
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Colored colored))
        {
            if (colored!=null)
            {
                colored.Paint(Color);
            }
        }
    }
}

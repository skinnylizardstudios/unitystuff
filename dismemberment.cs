if(tag == "Dismemberment")
            {
                Transform transformHit = hit.transform;
                BoxCollider boxCollider = transformHit.GetComponent<BoxCollider>();
                destroy dest = transformHit.GetComponent<destroy>();
                Transform mesh = dest.trans;
                boxCollider.enabled = false;
                Destroy(mesh.transform.gameObject);
            }

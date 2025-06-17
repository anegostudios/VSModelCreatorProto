using Riten.Native.Cursors;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalSizeDragger : MonoBehaviour
{

    public CanvasScaler mainCanvasScaler;
    public bool fromRightHandSide;
    public LayoutElement parentLayoutElement;

    bool isCurrentlyDrag;
    
    private void Update()
    {
        if (isCurrentlyDrag)
        {
            if (!Input.GetMouseButton(0))
            {
                isCurrentlyDrag = false;
                return;
            }

            if (fromRightHandSide)
            {
                parentLayoutElement.preferredWidth = (Screen.width - Input.mousePosition.x) / mainCanvasScaler.scaleFactor;
            }
            else
            {
                parentLayoutElement.preferredWidth = Input.mousePosition.x / mainCanvasScaler.scaleFactor;
            }
        }
    }

    public void OnBeginDrag()
    {
        isCurrentlyDrag = true;
    }

    public void OnCursorEnter()
    {
        NativeCursor.SetCursor(NTCursors.ResizeHorizontal);
    }

    public void OnCursorLeave()
    {
        NativeCursor.ResetCursor();
    }

}

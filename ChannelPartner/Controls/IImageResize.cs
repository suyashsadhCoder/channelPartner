using System;
using System.Collections.Generic;
using System.Text;

namespace ChannelPartner.Controls
{
    public interface IImageResize
    {
        byte[] ResizeImage(byte[] imageData, float width, float height, int quality);
    }
}

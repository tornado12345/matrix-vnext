/*
 * Copyright (c) 2003-2020 by AG-Software <info@ag-software.de>
 *
 * All Rights Reserved.
 * See the COPYING file for more information.
 *
 * This file is part of the MatriX project.
 *
 * NOTICE: All information contained herein is, and remains the property
 * of AG-Software and its suppliers, if any.
 * The intellectual and technical concepts contained herein are proprietary
 * to AG-Software and its suppliers and may be covered by German and Foreign Patents,
 * patents in process, and are protected by trade secret or copyright law.
 *
 * Dissemination of this information or reproduction of this material
 * is strictly forbidden unless prior written permission is obtained
 * from AG-Software.
 *
 * Contact information for AG-Software is available at http://www.ag-software.de
 */

using System.Text;
using System.Collections.Generic;
using DotNetty.Buffers;
using DotNetty.Codecs;
using DotNetty.Transport.Channels;
using Matrix.Attributes;

namespace Matrix.Network.Codecs
{
    [Name("UTF8String-Encoder")]
    public class UTF8StringEncoder : MessageToMessageEncoder<string>
    {
        public override bool IsSharable => true;
        protected override void Encode(IChannelHandlerContext context, string message, List<object> output)
        {
            if (message.Length == 0)
                return;

            output.Add(ByteBufferUtil.EncodeString(context.Allocator, message, Encoding.UTF8));
        }
    }
}

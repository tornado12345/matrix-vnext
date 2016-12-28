﻿using System.Threading.Tasks;
using Matrix.Xml;
using Matrix.Xmpp.Sasl;

namespace Matrix.Sasl
{
    public class DefaultSaslHandler : IAuthenticate
    {
        public async Task<XmppXElement> AuthenticateAsync(Mechanisms mechanisms, XmppClient xmppClient)
        {
            ISaslProcessor saslProc = null;
            if (mechanisms.SupportsMechanism(SaslMechanism.ScramSha1))
                saslProc = new ScramSha1Processor();

            //if (mechanisms.SupportsMechanism(SaslMechanism.DigestMd5))
            //    return new DigestMd5Processor();

            else if (mechanisms.SupportsMechanism(SaslMechanism.Plain))
                saslProc = new SaslPlainProcessor();

            return await saslProc.AuthenticateClientAsync(xmppClient);
        }
    }
}

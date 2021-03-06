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

using Matrix.Attributes;
using Matrix.Xml;

namespace Matrix.Xmpp.PubSub.Event
{
    [XmppTag(Name = "collection", Namespace = Namespaces.PubsubEvent)]
    public class Collection : XmppXElement
    {
        public Collection()
            : base(Namespaces.PubsubEvent, "collection")
        {
        }

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>The node.</value>
        public string Node
        {
            get { return GetAttribute("node"); }
            set { SetAttribute("node", value); }
        }

        public Associate Associate
        {
            get { return Element<Associate>(); }
            set
            {
                RemoveNodes();
                Add(value);
            }
        }

        public Disassociate Disassociate
        {
            get { return Element<Disassociate>(); }
            set
            {
                RemoveNodes();
                Add(value);
            }
        }

        //public CollectionType Type
        //{
        //    get
        //    {
        //        // order important because of inheritance
        //        if (Disassociate != null)
        //            return CollectionType.Disassociate;

        //        if (Associate != null)
        //            return CollectionType.Associate;

        //        return CollectionType.None;
        //    }
        //    set
        //    {
        //        RemoveNodes();
        //        switch (value)
        //        {
        //            case CollectionType.Disassociate:
        //                Add(new Disassociate());
        //                break;
        //            case CollectionType.Associate:
        //                Add(new Associate());
        //                break;
        //        }
        //    }
        //}
    }
}

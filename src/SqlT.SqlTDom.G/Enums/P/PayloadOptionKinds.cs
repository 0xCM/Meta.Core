////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum PayloadOptionKinds : int
    {
        None = 0,
        WebMethod = 1,
        Batches = 2,
        Wsdl = 4,
        Sessions = 8,
        LoginType = 16,
        SessionTimeout = 32,
        Database = 64,
        Namespace = 128,
        Schema = 256,
        CharacterSet = 512,
        HeaderLimit = 1024,
        Authentication = 2048,
        Encryption = 4096,
        MessageForwarding = 8192,
        MessageForwardSize = 16384,
        Role = 32768,
        SoapOptions = 2047,
        ServiceBrokerOptions = 30720,
        DatabaseMirroringOptions = 38912
    }
}
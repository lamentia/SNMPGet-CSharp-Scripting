#!/usr/bin/env dotnet-script
#r "nuget: SnmpSharpNet, 0.9.5"

using System;
using System.Collections.Generic;
using System.Text;
using SnmpSharpNet;

      // Get an SNMP Object
      

        string[] snmpAgent = new string[6];

        snmpAgent[0] = "xxx.xxx.xxx.xxx";
        snmpAgent[1] = "xxx.xxx.xxx.xxx";
        snmpAgent[2] = "xxx.xxx.xxx.xxx";
        snmpAgent[3] = "xxx.xxx.xxx.xxx";
        snmpAgent[4] = "xxx.xxx.xxx.xxx";
        snmpAgent[5] = "xxx.xxx.xxx.xxx";
        
      foreach(string ip in snmpAgent)
      {

      SimpleSnmp snmpVerb = new SimpleSnmp(ip, 161, "public");

      if (!snmpVerb.Valid)
      {
        Console.WriteLine("Seems that IP or community is not right");
        return;
      }


      // Sample of simple Get usage on SysName

      Oid oidSysName = new Oid("1.3.6.1.2.1.1.5.0");

      // Getting SysName

      Dictionary<Oid, AsnType> snmpDataS = snmpVerb.Get(SnmpVersion.Ver2, new string[] { oidSysName.ToString() });
      if (snmpDataS != null)
        Console.WriteLine("Name: \"{0}\" : {1}", ip, snmpDataS[oidSysName].ToString());
      else
        Console.WriteLine("Nothing!\"{0}\"",ip) ;
        }

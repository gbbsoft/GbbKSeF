/*
 * Author: Gbb Software 2002
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestKSeF
{
    internal static class KSeFHelpers
    {

        public static byte[] EncryptRSA(byte[] tab, string public_key)
        {
            // public key
            byte[] PublicKey = Convert.FromBase64String(public_key);
            //byte[] Exponent = { 1, 0, 1 };


            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                int ReadBytes;
                RSA.ImportSubjectPublicKeyInfo(PublicKey, out ReadBytes);

                var ret = RSA.Encrypt(tab, false);
                return ret;
            }
        }

        public static string Create_EncryptedToken(string Token, string public_key, DateTimeOffset Challenge_Timestamp)
        {
            // Base64(encrypt(public_key, (token + ‘|’ + challenge.getTime).getBytes))

            string s;
            byte[] tab;

            // string to encrypt
            s = Token + "|" + Challenge_Timestamp.ToUnixTimeMilliseconds().ToString();

            // string to encrypt
            tab = System.Text.ASCIIEncoding.UTF8.GetBytes(s);

            // encrypting
            s = Convert.ToBase64String(EncryptRSA(tab, public_key));
            return s;


        }

        public static Stream Create_InitSessionTokenRequest(string Challenge,
                                        string NIP, string EncryptedToken)
        {
            MemoryStream ms = new MemoryStream();

            XmlWriterSettings sett = new XmlWriterSettings();
            sett.Indent = true;
            sett.Encoding = Encoding.UTF8;

            XmlWriter w = XmlWriter.Create(ms, sett);
            w.WriteStartDocument(true);

            const string NS2 = "http://ksef.mf.gov.pl/schema/gtw/svc/types/2021/10/01/0001";
            const string NS3 = "http://ksef.mf.gov.pl/schema/gtw/svc/online/auth/request/2021/10/01/0001";
            const string XSI = "http://www.w3.org/2001/XMLSchema-instance";

            w.WriteStartElement("ns3", "InitSessionTokenRequest", NS3);
            w.WriteAttributeString("xmlns", "", null, "http://ksef.mf.gov.pl/schema/gtw/svc/online/types/2021/10/01/0001");
            w.WriteAttributeString("xmlns", "ns2", null, NS2);
            w.WriteAttributeString("xmlns", "ns3", null, NS3);
            {

                // Context
                w.WriteStartElement("Context", NS3);
                {
                    // Timestamp
                    // s = Challenge_TimeStamp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'");
                    //w.WriteElementString("Timestamp", s);

                    // Challenge
                    w.WriteElementString("Challenge", Challenge);

                    // Identifier
                    w.WriteStartElement("Identifier");
                    w.WriteAttributeString("xmlns", "xsi", null, XSI);
                    w.WriteAttributeString("type", XSI, "ns2:SubjectIdentifierByCompanyType");
                    {
                        w.WriteElementString("Identifier", NS2, NIP);
                    }
                    w.WriteEndElement(); // Identifier

                    // DocumentType
                    w.WriteStartElement("DocumentType");
                    {
                        w.WriteElementString("Service", NS2, "KSeF");
                        w.WriteStartElement("FormCode", NS2);
                        {
                            w.WriteElementString("SystemCode", NS2, "FA (1)");
                            w.WriteElementString("SchemaVersion", NS2, "1-0E");
                            w.WriteElementString("TargetNamespace", NS2, "http://crd.gov.pl/wzor/2021/11/29/11089/");
                            w.WriteElementString("Value", NS2, "FA");
                        }
                        w.WriteEndElement(); // FormCode
                    }
                    w.WriteEndElement(); // DocumentType

                    // Encryption

                    // Token
                    w.WriteElementString("Token", EncryptedToken);

                }
                w.WriteEndElement(); // Context

            }
            w.WriteEndElement(); // InitSessionTokenRequest
            w.WriteEndDocument();
            w.Close();

#if DEBUG
            s = Encoding.UTF8.GetString(ms.GetBuffer());
            File.WriteAllText(Path.Combine(Path.GetTempPath(), "!InitSessionTokenRequest.xml"), s);
#endif

            ms.Position = 0;
            return ms;


        }
        // ==============================
        // Batch Init
        //

        public class BatchInit_Params
        {
            public byte[]? SymetricAES_Key; // encrypted by RSA
            public byte[]? SymetricAES_InitVector;

            public byte[]? WholeZip_Hash;
            public string? WholeZip_Name;
            public long WholeZip_Length;


            public List<BatchInit_PartFile> PartFiles = new();
        }

        public class BatchInit_PartFile
        {
            public string? FileName;
            public long Length;
            public byte[]? Hash;
        }



        public static void Create_BatchInitRequest(string NIP, BatchInit_Params Params, string FileName)
        {
            string s;

            //System.Text.StringBuilder sb = new();
            MemoryStream ms = new MemoryStream();

            XmlWriterSettings sett = new XmlWriterSettings();
            sett.Indent = true;
            sett.Encoding = Encoding.UTF8;

            XmlWriter w = XmlWriter.Create(ms, sett);
            w.WriteStartDocument(false);

            const string NS = "http://ksef.mf.gov.pl/schema/gtw/svc/batch/init/request/2021/10/01/0001";
            const string NS_XSI = "http://www.w3.org/2001/XMLSchema-instance";
            const string NS_TYPES = "http://ksef.mf.gov.pl/schema/gtw/svc/types/2021/10/01/0001";
            const string NS_BATCH = "http://ksef.mf.gov.pl/schema/gtw/svc/batch/types/2021/10/01/0001";


            w.WriteStartElement("InitRequest", NS);
            w.WriteAttributeString("xmlns", "", null, NS);
            w.WriteAttributeString("xmlns", "xsi", null, NS_XSI);
            w.WriteAttributeString("xmlns", "types", null, NS_TYPES);
            w.WriteAttributeString("xmlns", "batch", null, NS_BATCH);
            {
                // NIP
                w.WriteStartElement("Identifier");
                w.WriteAttributeString("type", NS_XSI, "types:SubjectIdentifierByCompanyType");
                {
                    w.WriteElementString("Identifier", NS_TYPES, NIP);
                }
                w.WriteEndElement();

                // DocumentType
                w.WriteStartElement("DocumentType");
                {
                    w.WriteElementString("Service", NS_TYPES, "KSeF");
                    w.WriteStartElement("FormCode", NS_TYPES);
                    {
                        w.WriteElementString("SystemCode", NS_TYPES, "FA (1)");
                        w.WriteElementString("SchemaVersion", NS_TYPES, "1-0E");
                        w.WriteElementString("TargetNamespace", NS_TYPES, "http://ksef.mf.gov.pl/schema/gtw/svc/batch/init/request/2021/10/01/0001");
                        w.WriteElementString("Value", NS_TYPES, "FA");
                    }
                    w.WriteEndElement(); // FormCode
                }
                w.WriteEndElement();

                // Encryption
                w.WriteStartElement("Encryption");
                {
                    // EncryptionKey
                    w.WriteStartElement("EncryptionKey", NS_TYPES);
                    {
                        w.WriteElementString("Encoding", NS_TYPES, "Base64");
                        w.WriteElementString("Algorithm", NS_TYPES, "AES");
                        w.WriteElementString("Size", NS_TYPES, "256");
                        w.WriteElementString("Value", NS_TYPES, Convert.ToBase64String(Params.SymetricAES_Key!));
                    }
                    w.WriteEndElement();

                    // EncryptionInitializationVector
                    w.WriteStartElement("EncryptionInitializationVector", NS_TYPES);
                    {
                        w.WriteElementString("Encoding", NS_TYPES, "Base64");
                        w.WriteElementString("Bytes", NS_TYPES, "16");
                        w.WriteElementString("Value", NS_TYPES, Convert.ToBase64String(Params.SymetricAES_InitVector!));
                    }
                    w.WriteEndElement();

                    // EncryptionAlgorithmKey
                    w.WriteStartElement("EncryptionAlgorithmKey", NS_TYPES);
                    {
                        w.WriteElementString("Algorithm", NS_TYPES, "RSA");
                        w.WriteElementString("Mode", NS_TYPES, "ECB");
                        w.WriteElementString("Padding", NS_TYPES, "PKCS#1");
                    }
                    w.WriteEndElement();

                    // EncryptionAlgorithmData
                    w.WriteStartElement("EncryptionAlgorithmData", NS_TYPES);
                    {
                        w.WriteElementString("Algorithm", NS_TYPES, "AES");
                        w.WriteElementString("Mode", NS_TYPES, "CBC");
                        w.WriteElementString("Padding", NS_TYPES, "PKCS#7");
                    }
                    w.WriteEndElement();
                }
                w.WriteEndElement(); // Encryption

                w.WriteStartElement("PackageSignature");
                {
                    // Package
                    w.WriteStartElement("Package");
                    {
                        w.WriteElementString("PackageType", NS_BATCH, "split");
                        w.WriteElementString("CompressionType", NS_BATCH, "zip");
                        w.WriteElementString("Value", NS_BATCH, Params.WholeZip_Name);
                    }
                    w.WriteEndElement();

                    // PackageFileHash
                    w.WriteStartElement("PackageFileHash");
                    {
                        // HashSHA
                        w.WriteStartElement("HashSHA", NS_TYPES);
                        {
                            w.WriteElementString("Algorithm", NS_TYPES, "SHA-256");
                            w.WriteElementString("Encoding", NS_TYPES, "Base64");
                            w.WriteElementString("Value", NS_TYPES, Convert.ToBase64String(Params.WholeZip_Hash!));
                        }
                        w.WriteEndElement();
                        w.WriteElementString("FileSize", NS_TYPES, Params.WholeZip_Length.ToString());
                    }
                    w.WriteEndElement();

                    // PackagePartsList
                    w.WriteStartElement("PackagePartsList");
                    {
                        int OrderNo = 0;
                        foreach (var itm in Params.PartFiles)
                        {
                            w.WriteStartElement("PackagePartSignature");
                            {
                                OrderNo++;
                                w.WriteElementString("OrdinalNumber", NS_BATCH, OrderNo.ToString());
                                w.WriteElementString("PartFileName", NS_BATCH, itm.FileName);
                                w.WriteStartElement("PartFileHash", NS_BATCH);
                                {
                                    // HashSHA
                                    w.WriteStartElement("HashSHA", NS_TYPES);
                                    {
                                        w.WriteElementString("Algorithm", NS_TYPES, "SHA-256");
                                        w.WriteElementString("Encoding", NS_TYPES, "Base64");
                                        w.WriteElementString("Value", NS_TYPES, Convert.ToBase64String(itm.Hash!));
                                    }
                                    w.WriteEndElement();
                                    w.WriteElementString("FileSize", NS_TYPES, itm.Length.ToString());
                                }
                                w.WriteEndElement();
                            }
                            w.WriteEndElement();
                        }

                    }
                    w.WriteEndElement();

                }
                w.WriteEndElement();
            }
            w.WriteEndElement(); // InitRequest
            w.WriteEndDocument();
            w.Close();

            s = Encoding.UTF8.GetString(ms.GetBuffer());
            File.WriteAllText(FileName, s);
        }

        public static byte[] CalculateHash(string FullFileName, SHA256 mySHA256, out long Length)
        {
            using (var f = new System.IO.FileStream(FullFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                Length = f.Length;
                return mySHA256.ComputeHash(f);
            }
        }

        //public static byte[] GenerateRandomBytes(int length)
        //{
        //    var byteArray = new byte[length];
        //    RandomNumberGenerator.Fill(byteArray);
        //    return byteArray;
        //}

        // ==============================
        // Correction
        //

        public static byte[] CreateCorrection(string InvoiceXML, string NrKSeFFaKorygowanej,  string CorrNumber, string CorrReason)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(InvoiceXML);

            var Fa = FindChild(doc, doc.DocumentElement, "Fa", false);
            if (Fa == null)
                throw new ApplicationException("Brak elementu <Fa>");

            // dane faktury korygowanej
            var P_1 = FindChild(doc, Fa, "P_1", false)!;
            var P_2 = FindChild(doc, Fa, "P_2", false)!;
            var RodzajFaktury = FindChild(doc, Fa, "RodzajFaktury", false)!;
            string DataWyst = P_1.InnerText;
            string Numer = P_2.InnerText;
            string Rodzaj = RodzajFaktury.InnerText;

            // podmieniamy nagłówek
            P_1.InnerText = DateTime.Today.ToString("yyyy-MM-dd"); // XmlConvert.ToString(DateTime.Today,  XmlDateTimeSerializationMode.Unspecified);
            P_2.InnerText = CorrNumber;
            string RodzajKor;
            switch(Rodzaj)
            {
                case "VAT": case "KOR": RodzajKor = "KOR"; break;
                case "ZAL": case "KOR_ZAL": RodzajKor = "KOR_ZAL"; break;
                case "ROZ": case "KOR_ROZ": RodzajKor = "KOR_ROZ"; break;
                    default: throw new ApplicationException("Nieobsługiwany rodzaj faktury: " + Rodzaj);

            }
            RodzajFaktury.InnerText = RodzajKor;

            // wstawiamy dane o fakturze korygowanej
            FindChild(doc, Fa, "PrzyczynaKorekty", true)!.InnerText = CorrReason;
            FindChild(doc, Fa, "TypKorekty", true)!.InnerText = "2";

            var DaneKor = FindChild(doc, Fa, "DaneFaKorygowanej", true)!;
            FindChild(doc, DaneKor, "DataWystFaKorygowanej", true)!.InnerText = DataWyst;
            FindChild(doc, DaneKor, "NrFaKorygowanej", true)!.InnerText = Numer;
            FindChild(doc, DaneKor, "NrKSeFFaKorygowanej", true)!.InnerText = NrKSeFFaKorygowanej;

            // korekta wartości w nagłówku
            ChangeSign(doc, Fa, "P_13_1");
            ChangeSign(doc, Fa, "P_14_1");
            ChangeSign(doc, Fa, "P_14_1W");
            ChangeSign(doc, Fa, "P_13_2");
            ChangeSign(doc, Fa, "P_14_2");
            ChangeSign(doc, Fa, "P_14_2W");
            ChangeSign(doc, Fa, "P_13_3");
            ChangeSign(doc, Fa, "P_14_3");
            ChangeSign(doc, Fa, "P_14_3W");
            ChangeSign(doc, Fa, "P_13_4");
            ChangeSign(doc, Fa, "P_14_4");
            ChangeSign(doc, Fa, "P_14_4W");
            ChangeSign(doc, Fa, "P_13_5");
            ChangeSign(doc, Fa, "P_14_5");
            ChangeSign(doc, Fa, "P_13_6");
            ChangeSign(doc, Fa, "P_13_7");
            ChangeSign(doc, Fa, "P_15");

            // wiersze
            var FaWiersze = FindChild(doc, Fa, "FaWiersze", false);
            if (FaWiersze != null)
            {
                ChangeSign(doc, FaWiersze, "WartoscWierszyFaktury1");
                ChangeSign(doc, FaWiersze, "WartoscWierszyFaktury2");

                foreach(XmlNode itm0 in FaWiersze.ChildNodes)
                    if (itm0 is XmlElement itm && itm.Name == "FaWiersz")
                    {
                        ChangeSign(doc, itm, "P_8B"); // ilość
                        ChangeSign(doc, itm, "P_10"); // upusty
                        ChangeSign(doc, itm, "P_11"); // wartość
                        ChangeSign(doc, itm, "P_11A"); // wartość
                        ChangeSign(doc, itm, "KwotaAkcyzy"); // KwotaAkcyzy



                    }
            }

            // rozliczenie
            var Rozliczenie = FindChild(doc, Fa, "Rozliczenie", false);
            if (Rozliczenie != null)
            {
                foreach (XmlNode itm0 in Rozliczenie.ChildNodes)
                    if (itm0 is XmlElement itm && (itm.Name == "Obciazenia" || itm.Name == "Odliczenia"))
                    {
                        ChangeSign(doc, itm, "Kwota");
                    }

                ChangeSign(doc, FaWiersze, "SumaObciazen");
                ChangeSign(doc, FaWiersze, "SumaOdliczen");
                ChangeSign(doc, FaWiersze, "DoZaplaty");
                ChangeSign(doc, FaWiersze, "DoRozliczenia");
            }


            using (var mm = new MemoryStream())
            {
                doc.Save(mm);
                return mm.ToArray();
            }


        }

        private static void ChangeSign(XmlDocument doc, XmlElement? parent, string name)
        {
            var itm = FindChild(doc, parent, name, false);
            if (itm != null)
            {
                string s = itm.InnerText.Trim();
                if (s.StartsWith("-"))
                    s = s[1..];
                else
                    s = "-" + s;
                itm.InnerText = s;
            }
        }

        private static XmlElement? FindChild(XmlDocument doc, XmlElement? parent, string name, bool CreateIfMissing )
        {
            if (parent == null)
            {
                if (CreateIfMissing)
                    throw new ApplicationException("Brak rodzica, aby stworzyć element: " + name);
                return null;
            }
            
            foreach (XmlNode itm in parent.ChildNodes)
                if (itm is XmlElement e && e.Name == name)
                    return e;

            if (!CreateIfMissing)
                return null;

            XmlElement? element = doc.CreateElement(name);
            parent.AppendChild(element);
            return element;
        }

    }
}

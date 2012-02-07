using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Xml;
namespace OpenLauncher
{
	public class XmlHandler
	{
        public XmlDocument                 profile_xml;
        private FileStream                  profile_stream;
        protected string                    file_path = null, 
                                            file_name = null;
		
		
		private FileMode file_mode = FileMode.OpenOrCreate;
		private FileAccess file_access;
		private FileShare file_share;
		
        protected string file_full_path {
            get {
                return Path.Combine(file_path,file_name);
            }
        }
		
		public XmlHandler (string file_path, string file_name)
		{
			this.file_path = file_path;
			this.file_name = file_name;
			loadXml();
		}
		
		
		private void loadXml() {
            if(!Directory.Exists(file_path)) {
				//throw new IOException("Directory " + file_path + " not found");
			}
			if(!File.Exists(file_full_path)) {
				throw new FileNotFoundException("Could not find file " + file_full_path);
			}
				
            for(int i = 0;i<=5;i++) {
                try {
                    profile_stream = new FileStream(file_full_path,FileMode.Open,FileAccess.Read);
                    break;
                } catch (Exception e) {
                    if(i<5)
                        System.Threading.Thread.Sleep(100);
                    else
                        throw new IOException("Unable to open profile file", e);
                } finally {
                    if(profile_stream!=null)
                        profile_stream.Close();
                }
            }
			
            XmlReaderSettings xml_settings = new XmlReaderSettings();
            xml_settings.ConformanceLevel = ConformanceLevel.Document;
            xml_settings.IgnoreComments = true;
            xml_settings.IgnoreWhitespace = true;
            profile_xml = new XmlDocument();
            lock(profile_stream) {
                profile_stream = new FileStream(file_full_path, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlReader reader = XmlReader.Create(profile_stream, xml_settings);
                try {
                    profile_xml.Load(reader);
                } catch (XmlException e) {
					throw new IOException("XML Error while reading profile file", e);
                } finally {
                    reader.Close();
                    profile_stream.Close();
                }
            }
			processXml();
		}
		
		private void processXml() {
			lock(profile_xml) {
				
			}
		}
	}
}


using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VL2.ActiveRecord.Example
{
    public class ManagerActiveRecord
    {

        public static void DataBaseInitialize()
        {
            if (!ActiveRecordStarter.IsInitialized)
                ActiveRecordStarter.Initialize(typeof(Example.Student).Assembly, ActiveRecordSectionHandler.Instance);
        }

        public static string GenerateUpdateSchema()
        {
            DataBaseInitialize();
            string temp = "";
            var exceptions = UpdateSchema((s) => temp += s, false);
            if (exceptions.Count > 0)
                throw new Exception(exceptions[0].ToString());
            return temp;
        }

        private static IList UpdateSchema(Action<string> action, bool doUpdate)
        {
            CheckInitialized();
            ArrayList exceptions = new ArrayList();


            foreach (Configuration config in ActiveRecordMediator.GetSessionFactoryHolder().GetAllConfigurations())
            {
                SchemaUpdate updater = CreateSchemaUpdate(config);

                try
                {
                    updater.Execute(action, doUpdate);

                    exceptions.AddRange((IList)updater.Exceptions);
                }
                catch (Exception ex)
                {
                    throw new ActiveRecordException("Could not update the schema", ex);
                }
            }

            return exceptions;
        }

        private static void CheckInitialized()
        {
            if (!ActiveRecordStarter.IsInitialized)
            {
                throw new ActiveRecordException("Framework must be Initialized first.");
            }
        }

        private static SchemaUpdate CreateSchemaUpdate(Configuration cfg)
        {
            return new SchemaUpdate(cfg);
        }

    }



}


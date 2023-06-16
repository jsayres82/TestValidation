using System;
using System.Runtime.Serialization;

namespace Nuvo.Math.Core.Misc
{
	/// <summary>
	/// Simple Deserialization Binder
	/// </summary>
	// Token: 0x02000011 RID: 17
	public class SimpleDeserializationBinder : SerializationBinder
	{
		/// <summary>
		/// Bind to type
		/// </summary>
		/// <param name="assemblyName">Assembly name</param>
		/// <param name="typeName">Type name</param>
		/// <returns></returns>
		// Token: 0x0600012E RID: 302 RVA: 0x00007714 File Offset: 0x00005914
		public override Type BindToType(string assemblyName, string typeName)
		{
			if (typeName.Contains("[["))
			{
				string[] temp = typeName.Split(new char[]
				{
					'['
				});
				temp[0] = temp[0] + "[";
				for (int i = 2; i < temp.Length; i++)
				{
					char e = (i + 1 == temp.Length) ? ']' : ',';
					string[] temp2 = temp[i].Split(new char[]
					{
						','
					});
					temp[i] = string.Concat(new string[]
					{
						"[",
						temp2[0],
						",",
						temp2[1],
						"]",
						e.ToString()
					});
				}
				typeName = string.Concat(temp);
			}
			string shortAssemblyName = assemblyName.Split(new char[]
			{
				','
			})[0];
			return Type.GetType(string.Format("{0}, {1}", typeName, shortAssemblyName));
		}
	}
}

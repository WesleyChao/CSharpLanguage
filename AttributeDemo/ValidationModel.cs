using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    public class ValidationModel
    {

        public void Validate(object obj)
        {
            Type t = obj.GetType();

            //由于我们只在Property设置了Attibute,所以先获取Property
            // 获取所有的属性
            PropertyInfo[] properties = t.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //properties.
                //这里只做一个stringlength的验证，这里如果要做很多验证，需要好好设计一下,千万不要用if elseif去链接
                //会非常难于维护，类似这样的开源项目很多，有兴趣可以去看源码。
                //  MemberInfo.IsDefined(Type, Boolean)
                //  When overridden in a derived class, indicates whether one or more attributes of the specified type or of its derived types is applied to this member.
                if (!property.IsDefined(typeof(StringLengthAttribute), false))   // 这里 判断, 这个属性是否 
                {
                    continue;
                }

                // 这边是获取Attribute对象
                IEnumerable<Attribute> attributes = property.GetCustomAttributes();
                foreach (Attribute attribute in attributes)
                {
                    //这里的MaximumLength 最好用常量去做
                    Type ty = attribute.GetType();
                    PropertyInfo pro = ty.GetProperty("MaximumLength");
                    int maxinumLength = (int)pro.GetValue(attribute);

                    //获取属性的值
                    var propertyValue = property.GetValue(obj) as string;
                    if (propertyValue == null)
                        throw new Exception("exception info");//这里可以自定义，也可以用具体系统异常类

                    if (propertyValue.Length > maxinumLength)
                        throw new Exception(string.Format("属性{0}的值{1}的长度超过了{2}", property.Name, propertyValue, maxinumLength));
                }
            }

        }
    }
}

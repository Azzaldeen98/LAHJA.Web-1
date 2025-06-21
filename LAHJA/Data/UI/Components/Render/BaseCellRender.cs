using Microsoft.AspNetCore.Components;

namespace LAHJA.Data.UI.Components.Render
{



   public interface ICellRender
    {
        public  string Name { get; }
        public void Create(object data);

        public RenderFragment View();




    }
    public abstract class BaseCellRender: ICellRender
    {

        private readonly string _name;

        protected RenderFragment fragment;

        public string Name => _name;

        public BaseCellRender(string name)
        {
            _name = name;
        }
        public BaseCellRender()
        {
            _name = null;
        }
        public abstract void Create(object data);
        public abstract RenderFragment View();
    }

    public class AA1
    {

        public string Name { set; get; }
        public string Name1 { set; get; } = "gdfgdfg";


    }

    public  class  BB1
    {
        public ICellRender TTRTR { set; get; }=new CellRender();
        public string Name1 { set; get; }
        public string Name2 { set; get; }="TTT";

    }
}

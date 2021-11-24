

namespace CafeManagementApplication.controllers
{
    class LoadInfoController
    {
        private static LoadInfoController instance;
        public static LoadInfoController Instance
        {
            get
            {
                if (instance == null) instance = new LoadInfoController();
                return instance;
            }
        }

        private dynamic view;
        public dynamic View
        {
            get { return view; }
            set { view = value; }
        }
        public void LoadingInfoProduct(string name, string price, string tag)
        {
            this.view.LblNameText= name;
            this.view.LblNameTag = tag;
            this.view.LblPriceText = price;
        }
    }
}

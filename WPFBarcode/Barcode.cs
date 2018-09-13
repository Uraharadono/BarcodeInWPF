namespace WPFBarcode
{
    public class Barcode
    {
        public enum YesNoEnum
        {
            Yes,
            No
        }

        public enum BarcodeEnum
        {
            Code39
        }

        public string Data
        {
            get => data;
            set => data = value;
        }
        private string data;

        public BarcodeEnum BarcodeType
        {
            get => barcodeType;
            set => barcodeType = value;
        }
        private BarcodeEnum barcodeType;

        public YesNoEnum CheckDigit
        {
            get => checkDigit;
            set => checkDigit = value;
        }
        private YesNoEnum checkDigit;

        public string HumanText
        {
            get => humanText;
            set => humanText = value;
        }
        private string humanText;

        public string EncodedData
        {
            get => encodedData;
            set => encodedData = value;
        }
        private string encodedData;

        public void Encode()
        {
            int check = 0;
            if (checkDigit == Barcode.YesNoEnum.Yes)
                check = 1;

            if (barcodeType == BarcodeEnum.Code39)
            {
                Code39 barcode = new Code39();
                encodedData = barcode.encode(data, check);
                humanText = barcode.GetHumanText();
            }
        }
    }
}

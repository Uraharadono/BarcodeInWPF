using System.Diagnostics.CodeAnalysis;

namespace WPFBarcode
{
    public class Code39
    {
        // w - wide
        // t - thin
        // Start the drawing with black, white, black, white......
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public string encode(string data, int chk)
        {
            string fontOutput = mCode(data, chk);
            string output = "";
            string pattern = "";
            for (int x = 0; x < fontOutput.Length; x++)
            {
                switch (fontOutput[x])
                {
                    case '1':
                        pattern = "wttwttttwt";
                        break;
                    case '2':
                        pattern = "ttwwttttwt";
                        break;
                    case '3':
                        pattern = "wtwwtttttt";
                        break;
                    case '4':
                        pattern = "tttwwtttwt";
                        break;
                    case '5':
                        pattern = "wttwwttttt";
                        break;
                    case '6':
                        pattern = "ttwwwttttt";
                        break;
                    case '7':
                        pattern = "tttwttwtwt";
                        break;
                    case '8':
                        pattern = "wttwttwttt";
                        break;
                    case '9':
                        pattern = "ttwwttwttt";
                        break;
                    case '0':
                        pattern = "tttwwtwttt";
                        break;
                    case 'A':
                        pattern = "wttttwttwt";
                        break;
                    case 'B':
                        pattern = "ttwttwttwt";
                        break;
                    case 'C':
                        pattern = "wtwttwtttt";
                        break;
                    case 'D':
                        pattern = "ttttwwttwt";
                        break;
                    case 'E':
                        pattern = "wtttwwtttt";
                        break;
                    case 'F':
                        pattern = "ttwtwwtttt";
                        break;
                    case 'G':
                        pattern = "tttttwwtwt";
                        break;
                    case 'H':
                        pattern = "wttttwwttt";
                        break;
                    case 'I':
                        pattern = "ttwttwwttt";
                        break;
                    case 'J':
                        pattern = "ttttwwwttt";
                        break;
                    case 'K':
                        pattern = "wttttttwwt";
                        break;
                    case 'L':
                        pattern = "ttwttttwwt";
                        break;
                    case 'M':
                        pattern = "wtwttttwtt";
                        break;
                    case 'N':
                        pattern = "ttttwttwwt";
                        break;
                    case 'O':
                        pattern = "wtttwttwtt";
                        break;
                    case 'P':
                        pattern = "ttwtwttwtt";
                        break;
                    case 'Q':
                        pattern = "ttttttwwwt";
                        break;
                    case 'R':
                        pattern = "wtttttwwtt";
                        break;
                    case 'S':
                        pattern = "ttwtttwwtt";
                        break;
                    case 'T':
                        pattern = "ttttwtwwtt";
                        break;
                    case 'U':
                        pattern = "wwttttttwt";
                        break;
                    case 'V':
                        pattern = "twwtttttwt";
                        break;
                    case 'W':
                        pattern = "wwwttttttt";
                        break;
                    case 'X':
                        pattern = "twttwtttwt";
                        break;
                    case 'Y':
                        pattern = "wwttwttttt";
                        break;
                    case 'Z':
                        pattern = "twwtwttttt";
                        break;
                    case '-':
                        pattern = "twttttwtwt";
                        break;
                    case '.':
                        pattern = "wwttttwttt";
                        break;
                    case ' ':
                        pattern = "twwtttwttt";
                        break;
                    case '*':
                        pattern = "twttwtwttt";
                        break;
                    case '$':
                        pattern = "twtwtwtttt";
                        break;
                    case '/':
                        pattern = "twtwtttwtt";
                        break;
                    case '+':
                        pattern = "twtttwtwtt";
                        break;
                    case '%':
                        pattern = "tttwtwtwtt";
                        break;
                }
                output = output.Insert(output.Length, pattern);
            }
            return output;
        }

        private string humanText;
        static char[] CODE39MAP = {'0','1','2','3','4','5','6','7','8','9',
                             'A','B','C','D','E','F','G','H','I','J',
                             'K','L','M','N','O','P','Q','R','S','T',
                             'U','V','W','X','Y','Z','-','.',' ','$',
                             '/','+','%'};

        private string mCode(string data, int chk)
        {
            string cd = "", result = "";
            string filteredData = FilterInput(data);
            int filteredDataLength = filteredData.Length;

            if (chk == 1)
            {
                if (filteredDataLength > 254)
                    filteredData = filteredData.Remove(254, filteredDataLength - 254);
                cd = GenerateCheckDigit(filteredData);
            }
            else
            {
                if (filteredDataLength > 255)
                    filteredData = filteredData.Remove(255, filteredDataLength - 255);
            }

            result = "*" + filteredData + cd + "*";
            humanText = result;
            return result;
        }

        public string GetHumanText()
        {
            return humanText;
        }

        string GenerateCheckDigit(string data)
        {

            int dataLength = 0;
            int sum = 0;
            int result = -1;
            string strResult = "";
            char barcodeChar;

            dataLength = data.Length;
            for (int x = 0; x < dataLength; x++)
            {
                barcodeChar = data[x];
                sum = sum + GetCode39Value(barcodeChar);
            }
            result = sum % 43;
            strResult = GetCode39Character(result).ToString();

            return strResult;

        }

        char GetCode39Character(int inputDecimal)
        {
            return CODE39MAP[inputDecimal];
        }

        int GetCode39Value(char inputChar)
        {
            for (int x = 0; x < 43; x++)
            {
                if (CODE39MAP[x] == inputChar)
                    return x;
            }
            return -1;
        }

        string FilterInput(string data)
        {
            string result = "";
            int dataLength = data.Length;

            for (int x = 0; x < dataLength; x++)
            {
                char inputChar = data[x];
                if (GetCode39Value(inputChar) != -1)
                    result = result.Insert(result.Length, inputChar.ToString());
            }

            return result;
        }
    }
}

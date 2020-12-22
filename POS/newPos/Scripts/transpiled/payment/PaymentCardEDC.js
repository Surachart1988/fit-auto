

//var objComport = new ActiveXObject("ActiveXperts.Comport");
//function SendP(vAmount, vCode, vVolume, vPrice, PortNo) {

//    objComport.Device = PortNo;
//    objComport.BaudRate = 9600;
//    objComport.ComTimeout = 1000;
//    objComport.HardwareFlowControl = objComport.asFLOWCONTROL_DEFAULT;
//    objComport.Open();

//    if (objComport.IsOpened == -1) {

//        var STX = "02";
//        var llll = "0104";
//        var MeassageP = "544848484848484848484948504848484828";

//        var ProAmountH = "52480018";
//        var ProAmount = SetAmount(vAmount.toString());
//        var ProAmountFS = "28";
//        var mProAmount = ProAmountH + ProAmount + ProAmountFS;

//        var ProCodeH = "57490004";
//        var ProCode = "";
//        for (i = 0; i < vCode.length; i++) {
//            ProCode += vCode.charCodeAt(i);
//        }
//        var ProCodeFS = "28";
//        var mProCode = ProCodeH + ProCode + ProCodeFS;

//        var ProVolumeH = "57500018";
//        var ProVolume = SetAmount(vVolume.toString());
//        var ProVolumeFS = "28";
//        var mProVolume = ProVolumeH + ProVolume + ProVolumeFS;

//        var ProPriceH = "57510018";
//        var ProPrice = SetAmount(vPrice.toString());
//        var ProPriceFS = "28";
//        var mProPrice = ProPriceH + ProPrice + ProPriceFS;

//        var mPro = mProAmount + mProCode + mProVolume + mProPrice;

//        var ETX = "03";
//        var txtPurchase = STX + llll + MeassageP + mPro + ETX + CheckLRC(llll + MeassageP + mPro + ETX);

//        var j = 0;
//        for (i = 0; i < txtPurchase.length; i++) {
//            j += 2
//            objComport.writeByte(txtPurchase.substring(i, j));
//            i += 1
//        }

//        var recive = "";
//        var recivetmp = "";
//        var check = "F";
//        var exit_loop = 0;

//        while (objComport.LastError == 0 || objComport.LastError == 30115) {
//            recivetmp = objComport.ReadByte();

//            recive += recivetmp + ",";

//            if (recive.length >= 2000) {
//                objComport.Close();
//                break;
//            }

//            if (check == "F") {
//                check == "T"
//                if (recive.substr(0, 1) != "6") {
//                    objComport.Close();
//                    break;
//                }
//            }

//            if (recivetmp == "") {
//                exit_loop = exit_loop + 1;
//            }
//            else {
//                exit_loop = 0;
//            }

//            if (exit_loop == 40) {
//                objComport.Close();
//                break;
//            }
//        }

//        if (recive.substr(0, 1) == "6") {
//            var txt1 = ""
//            txt1 = recive;
//            var a;
//            var b = 0;
//            for (a = 0; a < txt1.length; a++) {
//                if (txt1.substr(a, 1) == "2") {
//                    b = a;
//                    break;
//                }
//            }

//            return recive;
//           // document.frmcard.action = "payment_card_purchase_save.asp";
//           // document.frmcard.target = "_self";
//           // document.frmcard.submit();
//        }
//        else {
//            alert("ไม่สามารถติดต่อธนาคารได้ในขณะนี้ กรุณาตรวจสอบ");
//            return "ไม่สามารถติดต่อธนาคารได้ในขณะนี้ กรุณาตรวจสอบ";
//          //  setTimeout("self.close()", 500);
//        }

//    }
//    else {
//        alert("ไม่สามารถติดต่อเครื่อง EDC ได้ กรุณาตรวจสอบ");
//        return "ไม่สามารถติดต่อธนาคารได้ในขณะนี้ กรุณาตรวจสอบ";
//      //  setTimeout("self.close()", 500);
//    }

//}

//function CheckLRC(txt) {
//    var LRC;
//    var y = 0;
//    for (x = 0; x < txt.length; x++) {
//        y += 2;
//        LRC = LRC ^ txt.substring(x, y);
//        x += 1;
//    }
//    return LRC;
//}

//function SetAmount(Amount) {

//    var a = "";
//    var b = Amount.replace('.', "");

//    for (i = 0; i < b.length; i++) {
//        a = a + "" + b.charCodeAt(i);
//    }

//    var countAmount = a.toString().length;
//    var HexAmount;
//    switch (countAmount) {
//        case 2:
//            HexAmount = "4848484848484848484848" + a; break;
//        case 4:
//            HexAmount = "48484848484848484848" + a; break;
//        case 6:
//            HexAmount = "484848484848484848" + a; break;
//        case 8:
//            HexAmount = "4848484848484848" + a; break;
//        case 10:
//            HexAmount = "48484848484848" + a; break;
//        case 12:
//            HexAmount = "484848484848" + a; break;
//        case 14:
//            HexAmount = "4848484848" + a; break;
//        case 16:
//            HexAmount = "48484848" + a; break;
//        case 18:
//            HexAmount = "484848" + a; break;
//        case 20:
//            HexAmount = "4848" + a; break;
//        case 22:
//            HexAmount = "48" + a; break;
//        case 12:
//            HexAmount = a; break;
//    }

//    return (HexAmount);

//}


//function GetTextPost(vAmount, vCode, vVolume, vPrice)
//{
//    var STX = "02";
//    var llll = "0104";
//    var MeassageP = "544848484848484848484948504848484828";

//    var ProAmountH = "52480018";
//    var ProAmount = SetAmount(vAmount.toString());
//    var ProAmountFS = "28";
//    var mProAmount = ProAmountH + ProAmount + ProAmountFS;

//    var ProCodeH = "57490004";
//    var ProCode = "";
//    for (i = 0; i < vCode.length; i++) {
//        ProCode += vCode.charCodeAt(i);
//    }
//    var ProCodeFS = "28";
//    var mProCode = ProCodeH + ProCode + ProCodeFS;

//    var ProVolumeH = "57500018";
//    var ProVolume = SetAmount(vVolume.toString());
//    var ProVolumeFS = "28";
//    var mProVolume = ProVolumeH + ProVolume + ProVolumeFS;

//    var ProPriceH = "57510018";
//    var ProPrice = SetAmount(vPrice.toString());
//    var ProPriceFS = "28";
//    var mProPrice = ProPriceH + ProPrice + ProPriceFS;

//    var mPro = mProAmount + mProCode + mProVolume + mProPrice;

//    var ETX = "03";
//    var TextPost = STX + llll + MeassageP + mPro + ETX + CheckLRC(llll + MeassageP + mPro + ETX);		

//    return TextPost;
//}


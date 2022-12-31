   var baslık = "@ViewBag.baslık";
        function printDiv(divName) {


            $.ajax({
                type: "POST",


                dataType: "json",
                contentType: "application/json; charset=utf-8",
                url: "/CARI_BASLIK/getcariinfo/",
                data: JSON.stringify({
                    kod: document.getElementById("CariKodu").options[document.getElementById("CariKodu").selectedIndex].value,


                }),
                success: function (result) {
                    cariadı = result.FIRMAUNVANI;
                    carikodu = result.CARIKOD;
                    cariadresi = result.ISADRES1;
                    caritelefon = result.ISTEL;

                    var printContents = document.getElementById("yazdirilcak").innerHTML;
                    var originalContents = document.body.innerHTML;
                    var content = "";

                    var FISNO = document.getElementById("FisNo").value;
                    var TARIH = document.getElementById("Tarih").value;
                    var NOT = document.getElementById("Not").value;
                    var toplamtutar = document.getElementById("toplam").value;
                    content += `<html lang="tr">
  <head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>${baslık}/title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no, shrink-to-fit=no" />

    <link href="assets/plugins/pace/pace-theme-flash.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

  </head>
  <body class="fixed-header">

    <div class=" container-fluid">

      <div class="row">
        <div class="col-md-12 text-center">
          <h4 class="m-0">${baslık} # ${FISNO}</h4>
          <hr>
        </div>
      </div>

      <div class="row d-flex justify-content-between align-items-end">
        <div class="col">
          <span class="font-weight-bold">Elkom Yazılım Egemen KERİMOĞLU</span> <br>
          <span>İstanbul Cad. 10/27 Ulus ANKARA</span>
        </div>
        <div class="col d-flex justify-content-end">
          <span class="mr-3 font-weight-bold">Fiş Tarih: ${TARIH}</span>
          <span class="font-weight-bold">Sayfa : 1</span>
        </div>
      </div>

      <hr>

      <div class="row">
        <div class="col-8">
          <table>
            <tbody>
            <tr>
              <td>Cari Adı </td>
              <td>:</td>
              <td>${carikodu + "/" + cariadı}</td>
            </tr>
            <tr>
              <td>Adres </td>
              <td>:</td>
              <td>${cariadresi}</td>
            </tr>
            <tr>
              <td>Telefon </td>
              <td>:</td>
              <td>${caritelefon}</td>
            </tr>
          </table>
        </div>
        <div class="col-4">
          <p>Açıklama: ${NOT}</p>
        </div>
      </div>
`;




                    content += printContents;
                    content += ` <div class="table-responsive">
                < table class="table table-striped table-sm" >

                    <tfoot>
                        <tr style="border-top: solid;">
                            <td></td>
                            <td>Toplam Tutar</td>
                            <td>${toplamtutar}</td>
                            <th class="text-right" scope="row" >Toplam:</th>
                            <th class="text-right" scope="row" >${toplamtutar}</th>
                            <th colspan="2" ></th>
                        </tr>


                    </tfoot>
                    <caption></caption>
        </table >
       </div>
    </div>
    </body>
    </html> `;
                    document.body.innerHTML = content;

                    window.print();

                    document.body.innerHTML = originalContents;
                    window.location = "/CARI_HAREKET/CARIFISLISTE";
                },
                error: function (result) {
                    alert('error');
                }
            });

        }
        function ceksenetdoldur() {

            $.ajax({
                type: "POST",


                dataType: "json",
                contentType: "application/json; charset=utf-8",
                url: "/CARI_BASLIK/getcariinfo/",
                data: JSON.stringify({
                    kod: document.getElementById("CariKodu").options[document.getElementById("CariKodu").selectedIndex].value,


                }),
                success: function (result) {
                   var cariadı = result.FIRMAUNVANI;

                    document.getElementById("KaşideEden").value = cariadı;

                    document.getElementById("KaşideYeri").value = result.VERGIDAIRESI;
                    document.getElementById("VergiNo").value = result.VERGINUMARASI;
                    document.getElementById("KaşideTarihi").value = "@DateTime.Now.Year.ToString("D" + 4)-@DateTime.Now.Month.ToString("D" + 2)-@DateTime.Now.Day.ToString("D" + 2)";

                    document.getElementById("SenetKesıdeEden").value = cariadı;

                    document.getElementById("SenetVergiDairesi").value = result.VERGIDAIRESI;
                    document.getElementById("SenetVergiNO").value = result.VERGINUMARASI;
                    document.getElementById("SenetKesıdeTarihi").value = "@DateTime.Now.Year.ToString("D" + 4)-@DateTime.Now.Month.ToString("D" + 2)-@DateTime.Now.Day.ToString("D" + 2)";

                    document.getElementById("SenetAderes").value = result.ISADRES1;
                    document.getElementById("SenetSehir").value = result.ISIL;

                },
                error: function (result) {
                    alert('error');
                }
            });
        }
            var ceksayisi =@Model.Ceksayisi;
                    var firmaceksayisi =@Model.FirmaCeksayisi;

            var firmasenetsayisi =@Model.FirmaSenetsayisi
            var senetsayisi =@Model.Senetsayisi;
        var visasayisi =@Model.VisaSayisi;

            var cekler = [];
            var senetler = [];
        var bakiyefiltre = null;
        var carid;
        var caridg;
        var carikodu;
        var cariadı;
        var cariadresi;
        var caritelefon;
        var kasaid;
        var kasadg;
            var kasakodu;
            var portfyno;
        var $table = $('#bootstrap-table');
        var $caritable = $('#caritablo');
            var $kasatable = $('#kasatablo');
            var $cek = $('#cektablosu');
        var $senet = $('#senettablosu');
        var $banka = $('#bankatable');
        var parakuru;
        var satir = null;
            $('#CariKodu').select2({
                 placeholder: "Cari adı veya kodu ile ara",
                ajax: {
                    url: '/CARI_BASLIK/getcari',
                    processResults: function (data) {
                        // Transforms the top-level key of the response object from 'items' to 'results'
                        return {
                            results: data

                        };
                    }
                    // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
                }
            });
            function carikurgetir() {
                $.ajax({
                    type: "POST",

                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "/CARI_BASLIK/getparabirimi/",
                    data: JSON.stringify({
                        kod: document.getElementById("CariKodu").options[document.getElementById("CariKodu").selectedIndex].value
                    }),
                    success: function (result) {
                        if (result != "TRY") {
                            var sel = document.getElementById("ParaBirimi");

                            var opts = sel.options;

                                kurgetir();

                        } else {
                            var sel = document.getElementById("ParaBirimi");

                            var opts = sel.options;

                            kurgetir();
                        }

                }
                    ,
                    error: function (result) {
                        alert('error');
                    }
                });
        }
        function get_query_paramscek(p) {



            var arr = [{ verismi: "TARIH", deger: "01/01/2000", deger2: "01/01/2090", filtretipi: 4 }];
            arr.push({ verismi: "CEKDURUMU", deger: "0", deger2: "01/01/2090", filtretipi: 2 });
            arr.push({});

            if (p.sort != null) {
                return {

                    extraParam: 'abc',
                    search: p.search,
                    sort: p.sort,
                    order: p.order,
                    limit: p.limit,
                    offset: p.offset,

                    sort: p.sort,

                    filterler: arr
                }
            } else {
                return {
                    extraParam: 'abc',
                    search: p.search,
                    sort: p.sort,
                    order: p.order,
                    limit: p.limit,
                    offset: p.offset,

                    sort: "ID",

                    filterler: arr
                }

            }
        }

                function get_query_paramssenet(p) {



                    var arr = [{ verismi: "TARIH", deger: "01/01/2000", deger2: "01/01/2090", filtretipi: 4 }];
                    arr.push({ verismi: "SENETDURUMU", deger: "0", deger2: "01/01/2090", filtretipi: 2 });
                    arr.push({});

                    if (p.sort != null) {
                        return {

                            extraParam: 'abc',
                            search: p.search,
                            sort: p.sort,
                            order: p.order,
                            limit: p.limit,
                            offset: p.offset,

                            sort: p.sort,

                            filterler: arr
                        }
                    } else {
                        return {
                            extraParam: 'abc',
                            search: p.search,
                            sort: p.sort,
                            order: p.order,
                            limit: p.limit,
                            offset: p.offset,

                            sort: "ID",

                            filterler: arr
                        }

                    }
                }
            function get_query_params(p) {



                var arr = [{ verismi: "TARIH", deger: "01/01/2000", deger2: "01/01/2090", filtretipi: 4 }];


                if (p.sort != null) {
                    return {

                        extraParam: 'abc',
                        search: p.search,
                        sort: p.sort,
                        order: p.order,
                        limit: p.limit,
                        offset: p.offset,

                        sort: p.sort,

                        filterler: arr
                    }
                } else {
                    return {
                        extraParam: 'abc',
                        search: p.search,
                        sort: p.sort,
                        order: p.order,
                        limit: p.limit,
                        offset: p.offset,

                        sort: "ID",

                        filterler: arr
                    }

                }
        }
        function get_query_paramsbanka(p) {



            var arr = [{ verismi: "BAKIYE", deger: 0, deger2: 0, filtretipi: 3}]
            if (p.sort != null) {
                return {

                    extraParam: 'abc',
                    search: p.search,
                    sort: p.sort,
                    order: p.order,
                    limit: p.limit,
                    offset: p.offset,

                    sort: p.sort,

                    filterler: arr
                }
            } else {
                return {
                    extraParam: 'abc',
                    search: p.search,
                    sort: p.sort,
                    order: p.order,
                    limit: p.limit,
                    offset: p.offset,

                    sort: "ID",

                    filterler: arr
                }

            }
        }
        function butonbankagetir(row) {
            row = satir;

            kasaidg = row.ID;
            document.getElementById("Adı").value = row.BANKAKODU;
            $('#ModalBanka').modal('hide');
            document.getElementById("Açıklama").value = visasayisi + "nolu Visa";


            ceksenetgetir();
        }
        function butoncekgetir(row) {
            row = satir;

            document.getElementById("Adı").value = row.PORTFOYNO;
            document.getElementById("NetTutar").value = row.TUTAR;
            document.getElementById("Tutar").value = row.TUTAR;
            document.getElementById("Açıklama").value = row.ACIKLAMA;
            document.getElementById("Vade").value = row.VADE;
            $('#ModalPORTFOYDAKICEKLER').modal('hide');
            document.getElementById("Açıklama").focus();
                cekler.push({ PORTFOYNO: portfyno, BANKADI: "", BANKASUBE: "", BANKAHESAPNO: "", ÇEKNO: "", KASIDEDEN: "", KASIDEYERI: "", KASIDETARIHI: "", VERGINO: "" });
        }
        function butonsenetgetir(row) {
            row = satir;

            senetler.push({ PORTFOYNO: portfyno, BANKADI: "", BANKASUBE: "", BANKAHESAPNO: "", ÇEKNO: "", KASIDEDEN: "", KASIDEYERI: "", KASIDETARIHI: "", VERGINO: "" });
            document.getElementById("Adı").value = row.PORTFOYNO;
            document.getElementById("NetTutar").value = row.TUTAR;
            document.getElementById("Tutar").value = row.TUTAR;
            document.getElementById("Açıklama").value = row.ACIKLAMA;
            document.getElementById("Vade").value = row.VADE;
            $('#ModalPORTFOYDAKISENETLER').modal('hide');
            document.getElementById("Açıklama").focus();
        }
           function ceksenetayarla() {


               butonkasalistele();
               $('#ModalKasaSec').modal('show');

            }
        function ceksenetgetir() {
            ceksenetdoldur();

                  var hareket = document.getElementById("Hareket").options[document.getElementById("Hareket").selectedIndex].value;
              @if (Url.RequestContext.HttpContext.Request.Url.ToString().Contains("GirişFiş"))
              {

                @: if (hareket == 1) {
                    @:  document.getElementById("Portfoyno").value = "AÇek" + (ceksayisi + 1).toString(); $("#ModalCEKGIRIS").modal('show'); }





                 @:  if (hareket == 2) {
                    @: document.getElementById("SenetPortfoyno").value = "ASenet"+(senetsayisi + 1); $("#ModalSENETGIRIS").modal('show');}

                 @:  if (hareket == 5) {
                    @:  $("#ModalBanka").modal('show'); visasayisi += 1;}
              }
              else
              {
                    @: if (hareket == 1) {
                    @: document.getElementById("FirmaPortfoyno").value = "FÇek"+(firmaceksayisi + 1); $("#ModalPORTFOYDAKICEKLER").modal('show'); }

                 @:  if (hareket == 2) {
                    @: document.getElementById("FirmaSenetPortfoyno").value = "FSenet" +(firmasenetsayisi + 1); $("#ModalPORTFOYDAKISENETLER").modal('show'); }
                  @:  if (hareket == 5) {
                    @:  $("#ModalBanka").modal('show'); visasayisi += 1;}
              }

            }

            function butonsenetekle() {
                document.getElementById("Adı").value = document.getElementById("SenetPortfoyno").value;
                senetler.push({PORTFOYNO: document.getElementById("SenetPortfoyno").value, KESIDEEDEN: document.getElementById("SenetKesıdeEden").value, KESIDETARIHI: document.getElementById("SenetKesıdeTarihi").value, ADRES: document.getElementById("SenetAderes").value, SEHIR: document.getElementById("SenetSehir").value, VERGİNO: document.getElementById("SenetVergiNO").value, VERGIDAIRESI: document.getElementById("SenetVergiDairesi").value });

                senetsayisi += 1;
            }
            function butoncekekle() {
                        document.getElementById("Adı").value = document.getElementById("Portfoyno").value;
                        cekler.push({ PORTFOYNO: document.getElementById("Portfoyno").value, BANKADI: document.getElementById("BankaAdı").value, BANKASUBE: document.getElementById("BankaSube").value, BANKAHESAPNO: document.getElementById("BankaNo").value, ÇEKNO: document.getElementById("ÇekNo").value, KASIDEDEN: document.getElementById("KaşideEden").value, KASIDEYERI: document.getElementById("KaşideYeri").value, KASIDETARIHI: document.getElementById("KaşideTarihi").value, VERGINO: document.getElementById("VergiNo").value });
                ceksayisi += 1;

            }
            function butonfirmasenetekle() {
                document.getElementById("Adı").value = document.getElementById("FirmaSenetPortfoyno").value;
                senetler.push({ PORTFOYNO: document.getElementById("FirmaSenetPortfoyno").value, KESIDEEDEN: "", KESIDETARIHI: "", ADRES: document.getElementById("FirmaSenetAderes").value, SEHIR: document.getElementById("FirmaSenetSehir").value, VERGİNO: document.getElementById("FirmaSenetVergiNO").value, VERGIDAIRESI: document.getElementById("FirmaSenetVergiDairesi").value });

                senetsayisi += 1;
            }
            function butonfirmacekekle() {
                document.getElementById("Adı").value = document.getElementById("FirmaPortfoyno").value;
                cekler.push({ PORTFOYNO: document.getElementById("FirmaPortfoyno").value, BANKADI: document.getElementById("FirmaBankaAdı").value, BANKASUBE: document.getElementById("FirmaBankaSube").value, BANKAHESAPNO: document.getElementById("FirmaBankaNo").value, ÇEKNO: document.getElementById("FirmaÇekNo").value, KASIDEDEN: "", KASIDEYERI: "", KASIDETARIHI: document.getElementById("KaşideTarihi").value, VERGINO: ""});
                ceksayisi += 1;

                }
        function butonkasalistele() {

        $.ajax({
            type: "POST",

            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "/CARI_HAREKET/kasagetir/",
            data: JSON.stringify({
                kasatipi: document.getElementById("Hareket").options[document.getElementById("Hareket").selectedIndex].text
            }),
            success: function (result) {

                $kasatable.bootstrapTable('load', result);
            },
            error: function (result) {
                alert('error');
            }
        });


    }
        function kurgetir() {
            var e = document.getElementById("ParaBirimi");
            document.getElementById("ParaBirimiKuru").value =e.options[e.selectedIndex].value;
            document.getElementById("NetTutar").value = parseFloat(document.getElementById("Tutar").value) *parseFloat(document.getElementById("ParaBirimiKuru").value);
        }
          function tutargetir() {

              document.getElementById("NetTutar").value = parseFloat(document.getElementById("Tutar").value) * parseFloat(document.getElementById("ParaBirimiKuru").value);
        }
        function tutargetirrowparabirimi(rowid) {
            console.log(rowid.parentNode.parentNode.childNodes[5].childNodes[0].value);
            rowid.parentNode.parentNode.childNodes[8].childNodes[0].value = numberformatter(parseFloat(rowid.parentNode.parentNode.childNodes[5].childNodes[0].value.toString().replaceAll(/,/g, '')) * rowid.value);
            yenile();
        }
        function tutargetirrowtutar(rowid) {

            rowid.parentNode.parentNode.childNodes[8].childNodes[0].value = numberformatter(parseFloat(rowid.parentNode.parentNode.childNodes[7].childNodes[1].value) * rowid.value);
            rowid.value = numberformatter(rowid.value);
            yenile();
        }
        function butoncarigetir() {

            carid = caridg;
            document.getElementById("CariKodu").value = carikodu;
            document.getElementById("ModalCariSec").style.display = "none";
            var sel = document.getElementById("ParaBirimi");
              var opts = sel.options;
            for (var opt, j = 0; opt = opts[j]; j++) {
                if (opt.text == parakuru) {
      sel.selectedIndex = j;
      break;
                }

            }
                kurgetir();

        }
        function butonkasagetir() {

            kasaid = kasadg;
            document.getElementById("Kasa").value = kasakodu;
            document.getElementById("ModalKasaSec").style.display = "none";
            document.getElementById("Açıklama").focus();
            ceksenetgetir();
        }
        function addRow(tableID) {

            var table = document.getElementById(tableID);

            var rowCount = table.rows.length;
            var row = table.insertRow(rowCount);

            var cell1 = row.insertCell(0);
            var element1 = document.createElement("input");
            element1.type = "text";
            element1.name = "txtbox[]";
            cell1.appendChild(element1);

            var cell2 = row.insertCell(1);
            var element2 = document.createElement("input");
            element2.type = "text";
            element2.name = "txtbox[]";
            cell2.appendChild(element2);

            var cell3 = row.insertCell(2);
            var element3 = document.createElement("input");
            element3.type = "text";
            element3.name = "txtbox[]";
            cell3.appendChild(element3);
            var cell4 = row.insertCell(3);
            var element4 = document.createElement("input");
            element4.type = "text";
            element4.name = "txtbox[]";
            cell4.appendChild(element4);

            var cell5 = row.insertCell(4);
            var element5 = document.createElement("input");
            element5.type = "text";
            element5.name = "txtbox[]";
            cell5.appendChild(element5);

            var cell6 = row.insertCell(5);
            var element6 = document.createElement("input");
            element6.type = "text";
            element6.name = "txtbox[]";
            cell6.appendChild(element6);
            var cell7 = row.insertCell(6);
            var element7 = document.createElement("input");
            element7.type = "text";
            element7.name = "txtbox[]";
            cell7.appendChild(element7);

        }

        $().ready(function () {

            $cek.bootstrapTable({

                type: "POST",
                url: "/CEK/ALINANFISDATA",
                method: 'post',
                contentType: 'application/x-www-form-urlencoded',
                queryParams: get_query_paramscek,

                clickToSelect: true,
                showRefresh: true,

                search: true,
                showToggle: true,
                showColumns: true,
                locale: 'tr-TR',
                searchAlign: 'left',
                formatShowingRows: function (pageFrom, pageTo, totalRows) {
                    //do nothing here, we don't want to show the text "showing x of y from..."
                },
                formatRecordsPerPage: function (pageNumber) {
                    return pageNumber + " rows visible";
                }

            });
            $cek.on('click-row.bs.table', function (e, row, $element) {
                satir = row;
                portfyno = row.PORTFOYNO;

            });
            $cek.on('  dbl-click-row.bs.table', function (e, row, $element) {
                portfyno = row.PORTFOYNO;
                cekler.push({ PORTFOYNO: portfyno, BANKADI: "", BANKASUBE: "", BANKAHESAPNO: "", ÇEKNO: "", KASIDEDEN: "", KASIDEYERI: "", KASIDETARIHI: "", VERGINO: "" });
                document.getElementById("Adı").value = row.PORTFOYNO;
                document.getElementById("NetTutar").value = row.TUTAR;
                document.getElementById("Tutar").value = row.TUTAR;
                document.getElementById("Açıklama").value = row.ACIKLAMA;
                document.getElementById("Vade").value = row.VADE;
                $('#ModalPORTFOYDAKICEKLER').modal('hide');
                document.getElementById("Açıklama").focus();

            });
            $senet.bootstrapTable({

                type: "POST",
                url: "/SENET/ALINANFISDATA",
                method: 'post',
                contentType: 'application/x-www-form-urlencoded',
                queryParams: get_query_paramssenet,

                clickToSelect: true,
                showRefresh: true,

                search: true,
                showToggle: true,
                showColumns: true,
                locale: 'tr-TR',
                searchAlign: 'left',
                formatShowingRows: function (pageFrom, pageTo, totalRows) {
                    //do nothing here, we don't want to show the text "showing x of y from..."
                },
                formatRecordsPerPage: function (pageNumber) {
                    return pageNumber + " rows visible";
                }

            });
            $senet.on('click-row.bs.table', function (e, row, $element) {

                portfyno = row.PORTFOYNO;
                satir = row;

            });
            $senet.on('  dbl-click-row.bs.table', function (e, row, $element) {
                portfyno = row.PORTFOYNO;
                senetler.push({ PORTFOYNO: portfyno, BANKADI: "", BANKASUBE: "", BANKAHESAPNO: "", ÇEKNO: "", KASIDEDEN: "", KASIDEYERI: "", KASIDETARIHI: "", VERGINO: "" });
                document.getElementById("Adı").value = row.PORTFOYNO;
                document.getElementById("NetTutar").value = row.TUTAR;
                document.getElementById("Tutar").value = row.TUTAR;
                document.getElementById("Açıklama").value = row.ACIKLAMA;
                document.getElementById("Vade").value = row.VADE;
                $('#ModalPORTFOYDAKISENETLER').modal('hide');
                document.getElementById("Açıklama").focus();

            });
            $caritable.bootstrapTable({

                clickToSelect: true,


                search: true,


                pagination: true,
                searchAlign: 'left',
                pageSize: 8,

                pageList: [8, 10, 25, 50, 100],
                locale: 'tr-TR',
                formatShowingRows: function (pageFrom, pageTo, totalRows) {
                    //do nothing here, we don't want to show the text "showing x of y from..."
                },
                formatRecordsPerPage: function (pageNumber) {
                    return pageNumber + " rows visible";
                },

            });

            $caritable.on('click-row.bs.table', function (e, row, $element) {
                caridg = row.ID;
                 carid = row.ID;
                carikodu = row.CARIKOD;
                carikodu = row.ADRES;
                parakuru = row.PARABIRIMI;
            });
            $caritable.on('  dbl-click-row.bs.table', function (e, row, $element) {
                carid = row.ID;
                parakuru = row.PARABIRIMI;
                document.getElementById("CariKodu").value = row.CARIKOD;
                     $('#ModalCariSec').modal('hide');
                       var sel = document.getElementById("ParaBirimi");
              var opts = sel.options;
                for (var opt, j = 0; opt = opts[j]; j++) {
                    if (opt.text == parakuru) {
                        sel.selectedIndex = j;
                        break;
                    }
                }
                   kurgetir();

            });


            $(window).resize(function () {
                $caritable.bootstrapTable('resetView');
            });



            $kasatable.bootstrapTable({


                clickToSelect: true,


                search: true,


                pagination: true,
                searchAlign: 'left',
                pageSize: 8,

                pageList: [8, 10, 25, 50, 100],
                locale: 'tr-TR',
                formatShowingRows: function (pageFrom, pageTo, totalRows) {
                    //do nothing here, we don't want to show the text "showing x of y from..."
                },
                formatRecordsPerPage: function (pageNumber) {
                    return pageNumber + " rows visible";
                },

            });

            $kasatable.on('click-row.bs.table', function (e, row, $element) {
                kasaidg = row.ID;
                kasakodu = row.KASAADI;

            });
            $kasatable.on('  dbl-click-row.bs.table', function (e, row, $element) {
                kasaidg = row.ID;

                document.getElementById("Kasa").value = row.KASAADI;
                $('#ModalKasaSec').modal('hide');


                ceksenetgetir();
            });



            $banka.bootstrapTable({
  type: "POST",
                    url: "/BANKAS/GetData",
                    method: 'post',
                    contentType: 'application/x-www-form-urlencoded',
                    queryParams: get_query_paramsbanka,
         printPageBuilder: function (table) {
        return `
<html>
  <head>
  <style type="text/css" media="print">
  page {
    size: auto;
    margin: 25px 0 25px 0;
  }
  </style>
  <style type="text/css" media="all">
  table {
    border-collapse: collapse;
    font-size: 12px;
  }
  table, th, td {
    border: 1px solid grey;
  }
  th, td {
    text-align: center;
    vertical-align: middle;
  }
  p {
    font-weight: bold;
    margin-left:20px;
  }
  table {
    width:94%;
    margin-left:3%;
    margin-right:3%;
  }
  div.bs-table-print {
    text-align:center;
  }
    h1.bs-table-print {
    text-align:center;
  }
  </style>
    <title>@Session["FirmaAdı"]</title>
     </head>
  <body>

     <h1 class="bs-table-print">Banka Listesi</h1>

  <div class="bs-table-print">${table}</div>
  </body>
</html>`
      },
                    clickToSelect: true,
                    showRefresh: true,

                    search: true,
                    showToggle: true,
                    showColumns: true,

                    searchAlign: 'left',

                    locale: 'tr-TR',
                    formatShowingRows: function (pageFrom, pageTo, totalRows) {
                        //do nothing here, we don't want to show the text "showing x of y from..."
                    },
                    formatRecordsPerPage: function (pageNumber) {
                        return pageNumber + " rows visible";
                    },

            });
            $banka.on('click-row.bs.table', function (e, row, $element) {
                document.getElementById("Adı").value=row.BANKAKODU;
                row = satir;
            });
            $banka.on('  dbl-click-row.bs.table', function (e, row, $element) {
                kasaidg = row.ID;
                document.getElementById("Adı").value = row.BANKAKODU;
                $('#ModalBanka').modal('hide');
                document.getElementById("Açıklama").value = visasayisi + "nolu Visa";


                ceksenetgetir();
            });


        })
        function butonlistele() {



            if (parseFloat(document.getElementById('NetTutar').value) == 0) {
                alert("Lütfen Tutar Giriniz!");
            } else {
                if (document.getElementById('Hareket').options[document.getElementById('Hareket').selectedIndex].value == 2 || document.getElementById('Hareket').options[document.getElementById('Hareket').selectedIndex].value == 1) {
                    if (document.getElementById('Adı').value == "") {
                        alert("Lütfen Çek Senet Giriniz!");
                    } else {
                        $table.append('<tr data-index="0"><td class="hareket" style="width: 85px;"><input class="form-control form-control-sm"value="' + document.getElementById('Hareket').options[document.getElementById('Hareket').selectedIndex].text + '"  readonly> </td><td style="width: 100px;">   <input type="text" readonly="" class="form-control form-control-sm" value="' + document.getElementById('Kasa').value + '"></td><td style="width: 76px;"><input type="text" class="form-control form-control-sm"  readonly="" value="' + document.getElementById('Adı').value + '"></td><td style="width: 220px"><input type="text" class="form-control form-control-sm" value="' + document.getElementById('Açıklama').value + '"></td><td><input type="date" class="form-control form-control-sm"  value="' + document.getElementById('Vade').value + '"></td><td style="width: 115px;"><input type="text" class="form-control form-control-sm text-right" onchange="tutargetirrowtutar(this)"  value="' + numberformatter(document.getElementById('Tutar').value) + '" required=""></td><td style="width: 76px;"><input class="form-control form-control-sm" value="' + document.getElementById('ParaBirimi').options[document.getElementById('ParaBirimi').selectedIndex].text + '" readonly></td><td style="width: 72px;"> <input type="text" class="form-control form-control-sm text-right" onchange="tutargetirrowparabirimi(this)" value="' + document.getElementById('ParaBirimiKuru').value + '"  required=""></td><td class="countable" style="width: 115px;"><input type="text" readonly="" value="' + numberformatter(document.getElementById('NetTutar').value) + '" class="form-control form-control-sm text-right" aria-describedby="net-tutar"></td><td> <button  type="button" id="deleteRowBtn" onclick="deleteRow(this)" class="btn btn-danger btn-sm btn-rounded noprint">  <span class="icon text-white-50">    <i class="fas fa-trash-alt"></i> </span></button></td></tr>');
                        document.getElementById('Adı').value = "";

                        document.getElementById('Açıklama').value = "";
                        document.getElementById('Tutar').value = "";
                        document.getElementById('NetTutar').value = "";
                        yenile();


                    }
                } else {
                    $table.append('<tr data-index="0"><td class="hareket" style="width: 85px;"><input class="form-control form-control-sm"value="' + document.getElementById('Hareket').options[document.getElementById('Hareket').selectedIndex].text + '"  readonly> </td><td style="width: 100px;">   <input type="text" readonly="" class="form-control form-control-sm" value="' + document.getElementById('Kasa').value + '"></td><td style="width: 76px;"><input type="text" class="form-control form-control-sm"  readonly="" value="' + document.getElementById('Adı').value + '"></td><td style="width: 220px"><input type="text" class="form-control form-control-sm" value="' + document.getElementById('Açıklama').value + '"></td><td><input type="date" class="form-control form-control-sm"  value="' + document.getElementById('Vade').value + '"></td><td style="width: 115px;"><input type="text" class="form-control form-control-sm text-right" onchange="tutargetirrowtutar(this)"  value="' + numberformatter(document.getElementById('Tutar').value) + '" required=""></td><td style="width: 76px;"><input class="form-control form-control-sm" value="' + document.getElementById('ParaBirimi').options[document.getElementById('ParaBirimi').selectedIndex].text + '" readonly></td><td style="width: 72px;"> <input type="text" class="form-control form-control-sm text-right" onchange="tutargetirrowparabirimi(this)" value="' + document.getElementById('ParaBirimiKuru').value + '"  required=""></td><td class="countable" style="width: 115px;"><input type="text" readonly="" value="' + numberformatter(document.getElementById('NetTutar').value) + '" class="form-control form-control-sm text-right" aria-describedby="net-tutar"></td><td> <button  type="button" id="deleteRowBtn" onclick="deleteRow(this)" class="btn btn-danger btn-sm btn-rounded noprint">  <span class="icon text-white-50">    <i class="fas fa-trash-alt"></i> </span></button></td></tr>');
                    document.getElementById('Adı').value = "";

                    document.getElementById('Açıklama').value = "";
                    document.getElementById('Tutar').value = "";
                    document.getElementById('NetTutar').value = "";
                    yenile();


                }


            }







        }
            function yenile() {
                var sum = 0;
                var nakit = 0;
                var senet = 0;
                var cek = 0;
                var table = document.getElementById("bootstrap-table");
                var ths = table.getElementsByTagName('th');
                var tds = table.getElementsByClassName('countable');
                var hareketler = table.getElementsByClassName('hareket');

                for (var i = 0; i < tds.length; i++) {
                    console.log(tds[i].childNodes[0].value);
                    var text = tds[i].childNodes[0].value.toString().replaceAll(/,/g, '');
                    var texta = hareketler[i].childNodes[0].value.toString();
                    if (texta== "Nakit") {
                        nakit += isNaN(text) ? 0 : parseFloat(text);
                    }
                    if (texta == "Çek") {
                        cek += isNaN(text) ? 0 : parseFloat(text);
                    }
                    if (texta == "Senet") {
                        senet+= isNaN(text) ? 0 : parseFloat(text);
                    }
                    sum += isNaN(text) ? 0 : parseFloat(text);

                }

                document.getElementById("nakitoplam").innerHTML = numberformatter(nakit);
                document.getElementById("senetoplam").innerHTML = numberformatter(senet);
                document.getElementById("cektoplam").innerHTML = numberformatter(cek);
                document.getElementById("toplam").value = numberformatter(sum);


            }
            function deleteRow(btn) {
                var row = btn.parentNode.parentNode;
                if (row.firstChild.innerHTML == "Çek") {


                        cekler.splice(row.index, 1);
                    ceksayisi -= 1;

                }
                if (row.firstChild.innerHTML == "Senet") {


                    senetler.splice(row.index, 1);
                    senetsayisi -= 1;

                }
                row.parentNode.removeChild(row);
                yenile();
        }



        function idFormatter() {
            return 'Toplam'
        }

        function nameFormatter(data) {
            return data.length
        }

        function numberformatter(value, row, index) {
            if (!value)
                return "0.00";
            else {
                return [

                    numberWithCommas((Number(value.toString().replace(",", "."))).toFixed(2))
                ].join('');
            }
        }
        function numberWithCommas(x) {
            return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
        function priceFormatter(data) {
            var field = this.field

            var toplam = data.map(function (row) {
                if (row[field])
                    return +Number(row[field].toString().replace(",", "."))
                else {
                    return +Number("0")
                }
            }).reduce(function (sum, i) {
                return sum + i
            }, 0);
            return numberformatter(toplam) + " TL"
        }

        function footerStyle(column) {
            return {
                id: {
                    classes: 'uppercase'
                },
                name: {
                    css: { 'font-weight': 'normal' }
                },
                price: {
                    css: { color: 'red' }
                }
            }[column.field]
        }


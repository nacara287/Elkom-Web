<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2" xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:clm54217="urn:un:unece:uncefact:codelist:specification:54217:2001" xmlns:clm5639="urn:un:unece:uncefact:codelist:specification:5639:1988" xmlns:clm66411="urn:un:unece:uncefact:codelist:specification:66411:2001" xmlns:clmIANAMIMEMediaType="urn:un:unece:uncefact:codelist:specification:IANAMIMEMediaType:2003" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:link="http://www.xbrl.org/2003/linkbase" xmlns:n1="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2" xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2" xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2" xmlns:xbrldi="http://xbrl.org/2006/xbrldi" xmlns:xbrli="http://www.xbrl.org/2003/instance" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" exclude-result-prefixes="cac cbc ccts clm54217 clm5639 clm66411 clmIANAMIMEMediaType fn link n1 qdt udt xbrldi xbrli xdt xlink xs xsd xsi">
  <xsl:character-map name="a">
    <xsl:output-character character="
" string="" />
    <xsl:output-character character="" string="" />
  </xsl:character-map>
  <xsl:decimal-format name="european" decimal-separator="," grouping-separator="." NaN="" />
  <xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd" use-character-maps="a" />
  <xsl:param name="SV_OutputFormat" select="'HTML'" />
  <xsl:variable name="XML" select="/" />
  <xsl:template match="/">
    <html>
      <head>
        <title />
        <style type="text/css">
                  body {
                  background-color: #FFFFFF;
                  font-family: 'Tahoma', "Times New Roman", Times, serif;
                  font-size: 11px;
                  color: black;
                  }
                  h1, h2 {
                  padding-bottom: 3px;
                  padding-top: 3px;
                  margin-bottom: 5px;
                  text-transform: uppercase;
                  font-family: Arial, Helvetica, sans-serif;
                  }
                  h1 {
                  font-size: 1.4em;
                  text-transform:none;
                  }
                  h2 {
                  font-size: 1em;
                  color: brown;
                  }
                  h3 {
                  font-size: 1em;
                  color: #333333;
                  text-align: justify;
                  margin: 0;
                  padding: 0;
                  }
                  h4 {
                  font-size: 1.1em;
                  font-style: bold;
                  font-family: Arial, Helvetica, sans-serif;
                  color: #000000;
                  margin: 0;
                  padding: 0;
                  }
                  #customername{				    
                  font-size:13px;
                  color: #005087;
                  }
                  p, ul, ol {
                  margin-top: 1.5em;
                  }
                  ul, ol {
                  margin-left: 3em;
                  }
                  blockquote {
                  margin-left: 3em;
                  margin-right: 3em;
                  font-style: italic;
                  }
                  a {
                  text-decoration: none;
                  color: #70A300;
                  }
                  a:hover {
                  border: none;
                  color: #70A300;
                  }
                  #despatchTable {
                  border-collapse:collapse;
                  font-size:11px;
                  float:right;
                  border-color:gray;
                  }
                  #ettnTable {
                  border-collapse:collapse;
                  font-size:11px;
                  border-color:gray;
                  }
                  #customerPartyTable {
                  border-width: 0px;
                  border-spacing:;
                  border-style: inset;
                  border-color: gray;
                  border-collapse: collapse;
                  background-color:
                  }
                  #customerIDTable {
                  border-width: 2px;
                  border-spacing:;
                  border-style: inset;
                  border-color: gray;
                  border-collapse: collapse;
                  background-color:
                  }
                  #customerIDTableTd {
                  border-width: 2px;
                  border-spacing:;
                  border-style: inset;
                  border-color: gray;
                  border-collapse: collapse;
                  background-color:
                  }
                  #lineTable {
                  border-width:2px;
                  border-spacing:;
                  border-style: solid;
                  border-color: #005087;
                  border-collapse: collapse;
                  background-color:;
                  }
                  #lineTableTd {
                  border-width: 1px;
                  padding: 1px;
                  border-style: solid;
                  border-color: #005087 ;						
                  }
                  #lineTableTr {
                  border-width: 1px;
                  padding: 0px;
                  background-color: white;
                  border-color: #005087 ;
                  -moz-border-radius:;
                  }
                  #lineTableDummyTd {
                  border-width: 1px;
                  border-color:white;
                  padding: 1px;
                  border-style: inset;
                  border-color: black;
                  background-color: white;
                  }
                  #lineTableBudgetTd {
                  }
                  #notesTable {
                  border-width: 1px;
                  border-spacing:;
                  border-style: solid;
                  border-color: #005087;
                  border-collapse: collapse;
                  background-color:
                  }
                  #notesTableTd {
                  border-width: 0px;
                  border-spacing:;
                  border-style: inset;
                  border-color: black;
                  border-collapse: collapse;
                  background-color:
                  }
                  table {
                  border-spacing:0px;
                  }
                  #budgetContainerTable {
                  border-collapse:collapse;
                  border-width: 0px;
                  border-spacing: 0px;
                  border-style: inset;
                  border-color: black;
                  background-color:;
                  margin-top: 7px;
                  margin-bottom: 30px;
                  }
                  #budgetContainerTable td{
                  border-bottom: 1px solid #ddd;
                  }
                  td {
                  border-color:gray;
                  }
                  @media print{
                  i{
                  font-style: italic !important;
                  }
                  }
                  #bankingTable{
                  border-collapse:collapse;
                  border-width: 1px;
                  border-style: inset;
                  font-size:11px;
                  float:leftt;
                  border-color:#005087;
                  }
                  #bankingTable th{
                  float:leftt;
                  border-color:gray;
                  background-color:#005087;
                  color: white;
                  }
               </style>
        <title>e-Fatura</title>
      </head>
      <body style="margin-left=0.6in; margin-right=0.6in; margin-top=0.79in; margin-bottom=0.79in">
        <xsl:for-each select="$XML">
          <table style="border-color:blue; " border="0" cellspacing="0px" width="800px" cellpadding="0px">
            <tbody>
              <tr valign="top">
                <td width="40%">
                  <br />
                  <br />
                  <table align="center" border="0" width="100%">
                    <tbody>
                      <tr align="left">
                        <xsl:for-each select="n1:Invoice/cac:AccountingSupplierParty/cac:Party">
                          <td align="left">
                            <xsl:if test="cac:PartyName">
                              <b id="customername">
                                <xsl:if test="cac:PartyName">
                                  <xsl:value-of select="cac:PartyName/cbc:Name" />
                                </xsl:if>
                              </b>
                            </xsl:if>
                          </td>
                        </xsl:for-each>
                      </tr>
                      <tr align="left">
                        <xsl:for-each select="n1:Invoice/cac:AccountingSupplierParty/cac:Party">
                          <td align="left">
                            <xsl:for-each select="cac:PostalAddress">
                              <xsl:for-each select="cbc:StreetName">
                                <xsl:apply-templates />
                                <xsl:text> </xsl:text>
                              </xsl:for-each>
                              <xsl:for-each select="cbc:BuildingName">
                                <xsl:apply-templates />
                              </xsl:for-each>
                              <br />
                              <xsl:for-each select="cbc:PostalZone">
                                <xsl:apply-templates />
                                <xsl:text> </xsl:text>
                              </xsl:for-each>
                              <xsl:for-each select="cbc:CitySubdivisionName">
                                <xsl:apply-templates />
                              </xsl:for-each>
                              <xsl:text>/ </xsl:text>
                              <xsl:for-each select="cbc:CityName">
                                <xsl:apply-templates />
                                <xsl:text> </xsl:text>
                              </xsl:for-each>
                              <xsl:text>/TURKEY</xsl:text>
                            </xsl:for-each>
                          </td>
                        </xsl:for-each>
                      </tr>
                      <xsl:if test="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:Telephone or //n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:Telefax">
                        <tr align="left">
                          <xsl:for-each select="n1:Invoice/cac:AccountingSupplierParty/cac:Party">
                            <td align="left">
                              <xsl:for-each select="cac:Contact">
                                <xsl:if test="cbc:Telephone">
                                  <xsl:text>Tel: </xsl:text>
                                  <xsl:for-each select="cbc:Telephone">
                                    <xsl:apply-templates />
                                  </xsl:for-each>
                                </xsl:if>
                                <xsl:if test="cbc:Telefax">
                                  <xsl:text> Fax: </xsl:text>
                                  <xsl:for-each select="cbc:Telefax">
                                    <xsl:apply-templates />
                                  </xsl:for-each>
                                </xsl:if>
                                <xsl:text> </xsl:text>
                              </xsl:for-each>
                            </td>
                          </xsl:for-each>
                        </tr>
                      </xsl:if>
                      <xsl:for-each select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cbc:WebsiteURI">
                        <tr align="left">
                          <td>
                            <xsl:text>Web Sitesi: </xsl:text>
                            <xsl:value-of select="." />
                          </td>
                        </tr>
                      </xsl:for-each>
                      <xsl:for-each select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:ElectronicMail">
                        <tr align="left">
                          <td>
                            <xsl:text>E-Posta: </xsl:text>
                            <xsl:value-of select="." />
                          </td>
                        </tr>
                      </xsl:for-each>
                      <tr align="left">
                        <xsl:for-each select="n1:Invoice/cac:AccountingSupplierParty/cac:Party">
                          <td align="left">
                            <xsl:text>Vergi Dairesi: </xsl:text>
                            <xsl:for-each select="cac:PartyTaxScheme">
                              <xsl:for-each select="cac:TaxScheme">
                                <xsl:for-each select="cbc:Name">
                                  <xsl:apply-templates />
                                </xsl:for-each>
                              </xsl:for-each>
                              <xsl:text>  </xsl:text>
                            </xsl:for-each>
                          </td>
                        </xsl:for-each>
                      </tr>
                      <xsl:for-each select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification">
                        <tr align="left">
                          <td>
                            <xsl:value-of select="cbc:ID/@schemeID" />
                            <xsl:text>: </xsl:text>
                            <xsl:value-of select="cbc:ID" />
                          </td>
                        </tr>
                      </xsl:for-each>
                    </tbody>
                  </table>
                </td>
                <td width="20%" align="center" valign="middle">
                  <img style="width:120px;" align="middle" alt="E-Fatura Logo" src="data:image/jpeg;base64,/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAABkAAD/4QMZaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjYtYzEzMiA3OS4xNTkyODQsIDIwMTYvMDQvMTktMTM6MTM6NDAgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjZDNDJBNEI2QjVCRDExRThCQjM0REIwQkZGMEQxODY0IiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjZDNDJBNEI1QjVCRDExRThCQjM0REIwQkZGMEQxODY0IiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDUzQgV2luZG93cyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSIzREVENkU1N0FDREVDNEJBNzkxNUM2M0NCN0RENzM0NyIgc3RSZWY6ZG9jdW1lbnRJRD0iM0RFRDZFNTdBQ0RFQzRCQTc5MTVDNjNDQjdERDczNDciLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz7/7gAOQWRvYmUAZMAAAAAB/9sAhAABAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEB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" />
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'EARSIVFATURA'">
                    <h1 align="center">
                      <span style="font-weight:bold; ">
                        <xsl:text>e-Arşiv Fatura</xsl:text>
                      </span>
                    </h1>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID != 'EARSIVFATURA'">
                    <h1 align="center">
                      <span style="font-weight:bold; ">
                        <xsl:text>e-Fatura</xsl:text>
                      </span>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <span style="font-size:10px;font-style:italic;color:#808080;">
                          <br />
                          <xsl:text>e-Invoice</xsl:text>
                        </span>
                      </xsl:if>
                    </h1>
                  </xsl:if>
                </td>
                <td align="center" valign="middle" width="20%">
                  <img alt="" src="data:image/jpeg;base64,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" />
                </td>
              </tr>
              <tr style="height:90px; " valign="top">
                <td width="40%" align="right" valign="bottom">
                  <table id="customerPartyTable" align="left" border="0" style="margin-top:50px;" height="40%">
                    <tbody>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID != 'IHRACAT'">
                        <tr style="height:35px; ">
                          <hr style="display: block;&#xD;&#xA;                                          height: 1px;&#xD;&#xA;                                          border: 0;&#xD;&#xA;                                          border-top: 1px solid #005087;&#xD;&#xA;                                          padding: 0; " />
                          <td>
                            <table align="center" border="0">
                              <tbody>
                                <tr>
                                  <xsl:for-each select="n1:Invoice/cac:AccountingCustomerParty/cac:Party">
                                    <td style="width:469px; " align="left">
                                      <span style="font-weight:bold;color:#005087; ">
                                        <xsl:text>Alıcı Bilgileri</xsl:text>
                                      </span>
                                      <!--	<i style="font-size:10px;font-style:italic !important;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                                                            <br/><xsl:text>Buyer Information</xsl:text>
                                                            </i> -->
                                    </td>
                                  </xsl:for-each>
                                </tr>
                                <tr>
                                  <xsl:choose>
                                    <xsl:when test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID='PARTYTYPE' and text()='TAXFREE']">
                                      <xsl:for-each select="n1:Invoice/cac:BuyerCustomerParty/cac:Party">
                                        <xsl:call-template name="Party_Title">
                                          <xsl:with-param name="PartyType">TAXFREE</xsl:with-param>
                                        </xsl:call-template>
                                      </xsl:for-each>
                                    </xsl:when>
                                    <xsl:otherwise>
                                      <xsl:for-each select="n1:Invoice/cac:AccountingCustomerParty/cac:Party">
                                        <xsl:call-template name="Party_Title">
                                          <xsl:with-param name="PartyType">OTHER</xsl:with-param>
                                        </xsl:call-template>
                                      </xsl:for-each>
                                    </xsl:otherwise>
                                  </xsl:choose>
                                </tr>
                                <xsl:choose>
                                  <xsl:when test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID='PARTYTYPE' and text()='TAXFREE']">
                                    <xsl:for-each select="n1:Invoice/cac:BuyerCustomerParty/cac:Party">
                                      <tr>
                                        <xsl:call-template name="Party_Adress">
                                          <xsl:with-param name="PartyType">TAXFREE</xsl:with-param>
                                        </xsl:call-template>
                                      </tr>
                                      <xsl:call-template name="Party_Other">
                                        <xsl:with-param name="PartyType">TAXFREE</xsl:with-param>
                                      </xsl:call-template>
                                    </xsl:for-each>
                                  </xsl:when>
                                  <xsl:otherwise>
                                    <xsl:for-each select="n1:Invoice/cac:AccountingCustomerParty/cac:Party">
                                      <tr>
                                        <xsl:call-template name="Party_Adress">
                                          <xsl:with-param name="PartyType">OTHER</xsl:with-param>
                                        </xsl:call-template>
                                      </tr>
                                      <xsl:call-template name="Party_Other">
                                        <xsl:with-param name="PartyType">OTHER</xsl:with-param>
                                      </xsl:call-template>
                                    </xsl:for-each>
                                  </xsl:otherwise>
                                </xsl:choose>
                              </tbody>
                            </table>
                            <hr style="display: block;&#xD;&#xA;                                             height: 1px;&#xD;&#xA;                                             border: 0;&#xD;&#xA;                                             border-top: 1px solid #005087;&#xD;&#xA;                                             padding: 0; " />
                          </td>
                        </tr>
                      </xsl:if>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <tr style="height:71px; ">
                          <td>
                            <hr style="display: block;&#xD;&#xA;                                             height: 1px;&#xD;&#xA;                                             border: 0;&#xD;&#xA;                                             border-top: 1px solid #005087;&#xD;&#xA;                                             padding: 0; " />
                            <table align="center" border="0">
                              <tbody>
                                <tr>
                                  <xsl:for-each select="n1:Invoice/cac:AccountingCustomerParty/cac:Party">
                                    <td style="width:469px; " align="left">
                                      <span style="font-weight:bold;color:#005087; ">
                                        <xsl:text>Alıcı Bilgileri</xsl:text>
                                      </span>
                                      <i style="font-size:10px;font-style:italic !important;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                                        <br />
                                        <xsl:text>Buyer Information</xsl:text>
                                      </i>
                                    </td>
                                  </xsl:for-each>
                                </tr>
                                <tr>
                                  <tr>
                                    <td style="width:469px" align="left">
                                      <span style="font-weight:bold; ">
                                        <xsl:text>
                                        </xsl:text>
                                      </span>
                                      <xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PartyLegalEntity/cbc:RegistrationName" />
                                    </td>
                                  </tr>
                                </tr>
                                <tr>
                                  <td style="width:469px" align="left">
                                    <xsl:if test="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:StreetName !=''&#xD;&#xA;               											     and  //n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:StreetName !='-'">
                                      <xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:StreetName" />
                                      <br />
                                    </xsl:if>
                                    <xsl:if test="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CitySubdivisionName !=''&#xD;&#xA;               											     and  //n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CitySubdivisionName !='-'">
                                      <xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CitySubdivisionName" />
                                      <xsl:text>/</xsl:text>
                                    </xsl:if>
                                    <xsl:if test="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CityName !=''&#xD;&#xA;													         and  //n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CitySubdivisionName !='-'">
                                      <xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CityName" />
                                      <xsl:text>/</xsl:text>
                                    </xsl:if>
                                    <xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cac:Country/cbc:Name" />
                                    <xsl:if test="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name !=''&#xD;&#xA;													         and  //n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name !='-'">
                                      <br />Tax Office:<xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name" /></xsl:if>
                                    <br />Company ID: <xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PartyLegalEntity/cbc:CompanyID" /></td>
                                </tr>
                                <tr>
                                  <td style="width:469px" align="left">
                                    <span style="font-weight:bold; ">
                                                          Consignee: <xsl:value-of select="(//n1:Invoice/cac:InvoiceLine/cac:Delivery/cbc:ID/node())[1]" /></span>
                                  </td>
                                </tr>
                                <tr>
                                  <td style="width:469px" align="left">
                                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:StreetName !=''&#xD;&#xA;													   and //n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:StreetName !='-' ">
                                      <xsl:value-of select="(//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:StreetName/node())[1]" />
                                      <br />
                                    </xsl:if>
                                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:CitySubdivisionName !=''&#xD;&#xA;													  and //n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:CitySubdivisionName  !='-'">
                                      <xsl:value-of select="(//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:CitySubdivisionName/node())[1]" />
                                      <xsl:text>/</xsl:text>
                                    </xsl:if>
                                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:CityName !=''&#xD;&#xA;													  and //n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:CityName !='-'">
                                      <xsl:value-of select="(//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cbc:CityName/node())[1]" />
                                      <xsl:text>/</xsl:text>
                                    </xsl:if>
                                    <xsl:value-of select="(//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryAddress/cac:Country/cbc:Name/node())[1]" />
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                            <hr style="display: block;&#xD;&#xA;                                             height: 1px;&#xD;&#xA;                                             border: 0;&#xD;&#xA;                                             border-top: 1px solid #005087;&#xD;&#xA;                                             padding: 0; " />
                          </td>
                        </tr>
                      </xsl:if>
                    </tbody>
                  </table>
                  <br />
                </td>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'EARSIVFATURA'">
                  <td width="20%" align="center">
                    <img alt="" style="padding-top:10px;" src="data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD/4QDQRXhpZgAATU0AKgAAAAgAAwE7AAIAAAAUAAAAModpAAQAAAABAAAARpydAAEAAAAiAAAApgAAAABCZXJrIMSwc21ldCDFnsO2bGVuAAAEkAMAAgAAABQAAAB8kAQAAgAAABQAAACQkpEAAgAAAAM0MQAAkpIAAgAAAAM0MQAAAAAAADIwMTg6MDE6MTAgMTA6MTA6NDYAMjAxODowMToxMCAxMDoxMDo0NgAAAEIAZQByAGsAIAAwAXMAbQBlAHQAIABeAfYAbABlAG4AAAD/2wBDAAcFBQYFBAcGBQYIBwcIChELCgkJChUPEAwRGBUaGRgVGBcbHichGx0lHRcYIi4iJSgpKywrGiAvMy8qMicqKyr/2wBDAQcICAoJChQLCxQqHBgcKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKir/wAARCAA7ACsDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD6RooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigD//Z" />
                  </td>
                </xsl:if>
                <td width="60%" align="center" valign="bottom" colspan="2">
                  <table border="0" height="13" id="despatchTable">
                    <tbody>
                      <tr>
                        <td style="width:105px;" align="left">
                          <span style="font-weight:bold;color:#005087; ">
                            <xsl:text>Özelleştirme No:</xsl:text>
                          </span>
                          <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                            <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <br />
                              <xsl:text>Customization Number</xsl:text>
                            </span>
                          </xsl:if>
                        </td>
                        <td style="width:110px;" align="left">
                          <xsl:for-each select="n1:Invoice/cbc:CustomizationID">
                            <xsl:apply-templates />
                          </xsl:for-each>
                        </td>
                      </tr>
                      <tr style="height:13px; ">
                        <td align="left">
                          <span style="font-weight:bold;color:#005087;  ">
                            <xsl:text>Senaryo:</xsl:text>
                          </span>
                          <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                            <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <br />
                              <xsl:text>Scenario</xsl:text>
                            </span>
                          </xsl:if>
                        </td>
                        <td align="left">
                          <xsl:for-each select="n1:Invoice/cbc:ProfileID">
                            <xsl:apply-templates />
                          </xsl:for-each>
                        </td>
                      </tr>
                      <tr style="height:13px; ">
                        <td align="left">
                          <span style="font-weight:bold;color:#005087;  ">
                            <xsl:text>Fatura Tipi:</xsl:text>
                          </span>
                          <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                            <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <br />
                              <xsl:text>Invoice Type</xsl:text>
                            </span>
                          </xsl:if>
                        </td>
                        <td align="left">
                          <xsl:for-each select="n1:Invoice/cbc:InvoiceTypeCode">
                            <xsl:apply-templates />
                          </xsl:for-each>
                        </td>
                      </tr>
                      <tr style="height:13px; ">
                        <td align="left">
                          <span style="font-weight:bold; color:#005087; ">
                            <xsl:text>Fatura No:</xsl:text>
                          </span>
                          <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                            <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <br />
                              <xsl:text>Invoice Number</xsl:text>
                            </span>
                          </xsl:if>
                        </td>
                        <td align="left">
                          <xsl:for-each select="n1:Invoice/cbc:ID">
                            <xsl:apply-templates />
                          </xsl:for-each>
                        </td>
                      </tr>
                      <tr style="height:13px; ">
                        <td align="left">
                          <span style="font-weight:bold; color:#005087; ">
                            <xsl:text>Fatura Tarihi:</xsl:text>
                          </span>
                          <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                            <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <br />
                              <xsl:text>Invoice Date</xsl:text>
                            </span>
                          </xsl:if>
                        </td>
                        <td align="left">
                          <xsl:for-each select="n1:Invoice/cbc:IssueDate">
                            <xsl:apply-templates select="." />
                          </xsl:for-each>
                        </td>
                      </tr>
                      <tr style="height:13px; ">
                        <td align="left">
                          <span style="font-weight:bold; color:#005087; ">
                            <xsl:text>Fatura Saati:</xsl:text>
                          </span>
                          <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                            <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <br />
                              <xsl:text>Invoice Time</xsl:text>
                            </span>
                          </xsl:if>
                        </td>
                        <td align="left">
                          <xsl:if test="//n1:Invoice/cbc:IssueTime != '' and //n1:Invoice/cbc:IssueTime != 'null'">
                            <xsl:for-each select="//n1:Invoice/cbc:IssueTime">
                              <xsl:value-of select="substring(.,1,8)" />
                            </xsl:for-each>
                          </xsl:if>
                        </td>
                      </tr>
                      <xsl:for-each select="n1:Invoice/cac:DespatchDocumentReference">
                        <tr style="height:13px; ">
                          <td align="left">
                            <span style="font-weight:bold; color:#005087; ">
                              <xsl:text>İrsaliye No:</xsl:text>
                            </span>
                            <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                              <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                                <br />
                                <xsl:text>Delivery Note</xsl:text>
                              </span>
                            </xsl:if>
                            <xsl:text> </xsl:text>
                          </td>
                          <td align="left">
                            <xsl:value-of select="cbc:ID" />
                          </td>
                        </tr>
                        <tr style="height:13px; ">
                          <td align="left">
                            <span style="font-weight:bold; color:#005087; ">
                              <xsl:text>İrsaliye Tarihi:</xsl:text>
                            </span>
                            <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                              <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                                <br />
                                <xsl:text>Delivery Note Date</xsl:text>
                              </span>
                            </xsl:if>
                          </td>
                          <td align="left">
                            <xsl:for-each select="cbc:IssueDate">
                              <xsl:apply-templates select="." />
                            </xsl:for-each>
                          </td>
                        </tr>
                      </xsl:for-each>
                      <xsl:if test="//n1:Invoice/cac:OrderReference">
                        <tr style="height:13px">
                          <td align="left">
                            <span style="font-weight:bold; color:#005087; ">
                              <xsl:text>Sipariş No:</xsl:text>
                            </span>
                            <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                              <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                                <br />
                                <xsl:text>Order Number</xsl:text>
                              </span>
                            </xsl:if>
                          </td>
                          <td align="left">
                            <xsl:for-each select="n1:Invoice/cac:OrderReference/cbc:ID">
                              <xsl:apply-templates />
                            </xsl:for-each>
                          </td>
                        </tr>
                      </xsl:if>
                      <xsl:if test="//n1:Invoice/cac:OrderReference/cbc:IssueDate">
                        <tr style="height:13px">
                          <td align="left">
                            <span style="font-weight:bold; color:#005087; ">
                              <xsl:text>Sipariş Tarihi:</xsl:text>
                            </span>
                            <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                              <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                                <br />
                                <xsl:text>Order Date</xsl:text>
                              </span>
                            </xsl:if>
                          </td>
                          <td align="left">
                            <xsl:for-each select="n1:Invoice/cac:OrderReference/cbc:IssueDate">
                              <xsl:apply-templates select="." />
                            </xsl:for-each>
                          </td>
                        </tr>
                      </xsl:if>
                      <xsl:for-each select="n1:Invoice/cac:TaxRepresentativeParty/cac:PartyIdentification/cbc:ID[@schemeID='ARACIKURUMVKN']">
                        <tr>
                          <td style="width:105px;" align="left">
                            <span style="font-weight:bold;color:#005087;  ">
                              <xsl:text>Aracı Kurum VKN:</xsl:text>
                            </span>
                          </td>
                          <td style="width:110px;" align="left">
                            <xsl:value-of select="." />
                          </td>
                        </tr>
                        <tr>
                          <td style="width:105px;" align="left">
                            <span style="font-weight:bold;color:#005087;  ">
                              <xsl:text>Aracı Kurum Unvan:</xsl:text>
                            </span>
                          </td>
                          <td style="width:110px;" align="left">
                            <xsl:value-of select="../../cac:PartyName/cbc:Name" />
                          </td>
                        </tr>
                      </xsl:for-each>
                      <xsl:if test="contains(.,'#GTB_REFNO:')">
                        <tr style="height:13px; ">
                          <td align="left">
                            <span style="font-weight:bold; color:#005087; ">
                              <xsl:text>Gtb Refno:</xsl:text>
                            </span>
                            <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <br />
                              <xsl:text>Gtb Refno</xsl:text>
                            </span>
                          </td>
                          <td align="left">
                            <xsl:value-of select="substring-before(substring-after(.,'#GTB_REFNO:'),'~;')" />
                          </td>
                        </tr>
                      </xsl:if>
                      <xsl:if test="contains(.,'#GTB_GCB_TESCILNO:')">
                        <tr style="height:13px; ">
                          <td align="left">
                            <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                              <span style="font-weight:bold; color:#005087; ">
                                <xsl:text>Gtb Gcb Tescil No:</xsl:text>
                              </span>
                              <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                                <br />
                                <xsl:text>Gtb GcbRegistrationNo</xsl:text>
                              </span>
                            </xsl:if>
                          </td>
                          <td align="left">
                            <xsl:value-of select="substring-before(substring-after(.,'#GTB_GCB_TESCILNO:'),'~;')" />
                          </td>
                        </tr>
                      </xsl:if>
                      <xsl:if test="contains(.,'#GTB_FIILI_IHRACAT_TARIHI:')">
                        <tr style="height:13px; ">
                          <td align="left">
                            <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                              <span style="font-weight:bold; color:#005087; ">
                                <xsl:text>Gtb Fiili İhracat Tarihi:</xsl:text>
                              </span>
                              <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                                <br />
                                <xsl:text>Gtb ActualExportDate</xsl:text>
                              </span>
                            </xsl:if>
                          </td>
                          <td align="left">
                            <xsl:value-of select="substring-before(substring-after(.,'#GTB_FIILI_IHRACAT_TARIHI:'),'~;')" />
                          </td>
                        </tr>
                      </xsl:if>
                    </tbody>
                  </table>
                </td>
              </tr>
              <tr align="left">
                <table id="ettnTable">
                  <tr style="height:13px;">
                    <td align="left" valign="top">
                      <span style="font-weight:bold; color:#005087;">
                        <xsl:text>ETTN:</xsl:text>
                      </span>
                    </td>
                    <td align="left" width="240px">
                      <xsl:for-each select="n1:Invoice/cbc:UUID">
                        <xsl:apply-templates />
                      </xsl:for-each>
                    </td>
                  </tr>
                </table>
              </tr>
            </tbody>
          </table>
          <br />
          <div id="lineTableAligner">
            <span>
              <xsl:text> </xsl:text>
            </span>
          </div>
          <table border="1" id="lineTable" width="800px">
            <tbody>
              <tr id="lineTableTr">
                <td id="lineTableTd" style="width:4%;background-color:#005087;color:#fff;">
                  <span style="font-weight:bold; font-size:9px; color:#fff;" align="center">
                    <xsl:text>S.N</xsl:text>
                    <br />
                  </span>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <span style="font-size:9px;font-style:italic;">
                      <xsl:text>Q.N</xsl:text>
                    </span>
                  </xsl:if>
                </td>
                <xsl:if test="//n1:Invoice//cac:InvoiceLine/cac:Item/cbc:BrandName != ''">
                  <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                    <span style="font-weight:bold; font-size:9px;color:#fff;" align="center">
                      <xsl:text>Marka</xsl:text>
                      <br />
                    </span>
                    <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Brand</xsl:text>
                      </span>
                    </xsl:if>
                  </td>
                </xsl:if>
                <xsl:if test="//n1:Invoice/cbc:ProfileID != 'IHRACAT'">
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:SellersItemIdentification/cbc:ID != ''">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;">
                      <span style="font-weight:bold;font-size:9px; color:#fff;" align="center">
                        <xsl:text>Ürün Kodu </xsl:text>
                        <br />
                      </span>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <span style="font-size:9px;font-style:italic;">
                          <xsl:text>Seller Code</xsl:text>
                        </span>
                      </xsl:if>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:BuyersItemIdentification/cbc:ID != ''">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;">
                      <span style="font-weight:bold; font-size:9px; color:#fff;" align="center">
                        <xsl:text>Alıcı Ü. Kodu </xsl:text>
                        <br />
                      </span>
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Buyer Code</xsl:text>
                      </span>
                    </td>
                  </xsl:if>
                </xsl:if>
                <td height="25" id="lineTableTd" bgcolor="#005087" style="color:#fff;" align="center">
                  <span style="font-weight:bold;font-size:9px; ">
                    <xsl:text>Mal/Hizmet</xsl:text>
                    <br />
                  </span>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <span style="font-size:9px;font-style:italic;">
                      <xsl:text>Product</xsl:text>
                    </span>
                  </xsl:if>
                </td>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:NetWeightMeasure  != '0'">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;">
                      <span style="font-weight:bold;font-size:9px; color:#fff;" align="center">
                        <xsl:text>Net </xsl:text>
                        <br />
                      </span>
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Net</xsl:text>
                      </span>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:GrossWeightMeasure != '0'">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;">
                      <span style="font-weight:bold; font-size:9px; color:#fff;" align="center">
                        <xsl:text>Brüt </xsl:text>
                        <br />
                      </span>
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Gross</xsl:text>
                      </span>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine//cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:Quantity != ''">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                      <span style="font-weight:bold;font-size:9px;">
                        <xsl:text>Kap Adedi</xsl:text>
                        <br />
                      </span>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <span style="font-size:9px;font-style:italic;">
                          <xsl:text>N.of Boxes</xsl:text>
                        </span>
                      </xsl:if>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine//cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode != ''">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                      <span style="font-weight:bold;font-size:9px;">
                        <xsl:text>Kap Cinsi</xsl:text>
                        <br />
                      </span>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <span style="font-size:9px;font-style:italic;">
                          <xsl:text>Packaging</xsl:text>
                        </span>
                      </xsl:if>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cbc:Note != ''">
                    <td height="25" id="lineTableTd" bgcolor="#005087" style="color:#fff;" align="center">
                      <span style="font-weight:bold;font-size:9px; ">
                        <xsl:text>Şale</xsl:text>
                        <br />
                      </span>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <span style="font-size:9px;font-style:italic;">
                          <xsl:text>Punnet</xsl:text>
                        </span>
                      </xsl:if>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cbc:Description != ''">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                      <span style="font-weight:bold;font-size:9px;">
                        <xsl:text>Palet</xsl:text>
                        <br />
                      </span>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <span style="font-size:9px;font-style:italic;">
                          <xsl:text>Pallet</xsl:text>
                        </span>
                      </xsl:if>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cbc:ModelName != ''">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                      <span style="font-weight:bold; font-size:9px;">
                        <xsl:text>Parti No</xsl:text>
                        <br />
                      </span>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <span style="font-size:9px;font-style:italic;">
                          <xsl:text>Part No</xsl:text>
                        </span>
                      </xsl:if>
                    </td>
                  </xsl:if>
                </xsl:if>
                <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                  <span style="font-weight:bold;font-size:9px;">
                    <xsl:text> Miktar</xsl:text>
                    <br />
                  </span>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <span style="font-size:9px;font-style:italic;">
                      <xsl:text>Quantity</xsl:text>
                    </span>
                  </xsl:if>
                </td>
                <td id="lineTableTd" style="background-color:#005087;color:#fff;">
                  <span style="font-weight:bold; font-size:9px; color:#fff;" align="center">
                    <xsl:text>Birim</xsl:text>
                    <br />
                  </span>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <span style="font-size:9px;font-style:italic;">
                      <xsl:text>Unit</xsl:text>
                    </span>
                  </xsl:if>
                </td>
                <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                  <span style="font-weight:bold;font-size:9px; ">
                    <xsl:text> Fiyat</xsl:text>
                    <br />
                  </span>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <span style="font-size:9px;font-style:italic;">
                      <xsl:text>Unit Price</xsl:text>
                    </span>
                  </xsl:if>
                </td>
                <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge/cbc:Amount != 0">
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge/cbc:AllowanceChargeReason !='' ">
                    <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                      <span style="font-weight:bold; font-size:9px; ">
                        <xsl:text>iskonto Açıklama</xsl:text>
                        <br />
                      </span>
                      <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <span style="font-size:9px;font-style:italic;">
                          <xsl:text>Discount Description %</xsl:text>
                        </span>
                      </xsl:if>
                    </td>
                  </xsl:if>
                  <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                    <span style="font-weight:bold; font-size:9px; ">
                      <xsl:text>İskonto O.</xsl:text>
                      <br />
                    </span>
                    <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Discount %</xsl:text>
                      </span>
                    </xsl:if>
                  </td>
                  <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                    <span style="font-weight:bold;font-size:9px; ">
                      <xsl:text>İskonto T.</xsl:text>
                      <br />
                    </span>
                    <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Discount A.</xsl:text>
                      </span>
                    </xsl:if>
                  </td>
                </xsl:if>
                <xsl:if test="//n1:Invoice/n1:Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount != 0">
                  <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                    <span style="font-weight:bold;font-size:9px; ">
                      <xsl:text>KDV O.</xsl:text>
                      <br />
                    </span>
                    <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>VAT %</xsl:text>
                      </span>
                    </xsl:if>
                  </td>
                  <td id="lineTableTd" style="background-color:#005087;color:#fff;" align="center">
                    <span style="font-weight:bold;font-size:9px; ">
                      <xsl:text>KDV Tutarı</xsl:text>
                      <br />
                    </span>
                    <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>VAT Amount</xsl:text>
                      </span>
                    </xsl:if>
                  </td>
                </xsl:if>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                  <td height="25" id="lineTableTd" bgcolor="#005087" style="color:#fff;" align="center">
                    <span style="font-weight:bold;font-size:9px; ">
                      <xsl:text>Gönd. Şekli</xsl:text>
                      <br />
                    </span>
                    <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Sending Form</xsl:text>
                      </span>
                    </xsl:if>
                  </td>
                  <td height="25" id="lineTableTd" bgcolor="#005087" style="color:#fff;" align="center">
                    <span style="font-weight:bold;font-size:9px; ">
                      <xsl:text>Gtip No</xsl:text>
                      <br />
                    </span>
                    <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Gtip No</xsl:text>
                      </span>
                    </xsl:if>
                  </td>
                  <td height="25" id="lineTableTd" bgcolor="#005087" style="color:#fff;" align="center">
                    <span style="font-weight:bold;font-size:9px;">
                      <xsl:text>Teslim Şartı</xsl:text>
                      <br />
                    </span>
                    <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                      <span style="font-size:9px;font-style:italic;">
                        <xsl:text>Delivery Cond.</xsl:text>
                      </span>
                    </xsl:if>
                  </td>
                </xsl:if>
                <td height="25" id="lineTableTd" bgcolor="#005087" style="color:#fff;" align="center">
                  <span style="font-weight:bold;font-size:9px; ">
                    <xsl:text>Tutar</xsl:text>
                    <br />
                  </span>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <span style="font-size:9px;font-style:italic;">
                      <xsl:text>Amount</xsl:text>
                    </span>
                  </xsl:if>
                </td>
                <!--  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:InsuranceValueAmount
					             or //n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:DeclaredForCarriageValueAmount
					            or //n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:FreeOnBoardValueAmount 								
								">
						 <td height="25" id="lineTableTd" bgcolor="#005087" style="color:#fff;" align="center">
                           <span style="font-weight:bold;font-size:9px; ">
                              <xsl:text>Satır Toplamı</xsl:text>
                              <br/>
                           </span>
                           <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                              <span style="font-size:9px;font-style:italic;">
                                 <xsl:text>Line Total</xsl:text>
                              </span>
                           </xsl:if>
                        </td>
					  </xsl:if>-->
              </tr>
              <xsl:for-each select="//n1:Invoice/cac:InvoiceLine">
                <tr id="lineTableTr">
                  <td id="lineTableTd" align="center">
                    <xsl:value-of select="./cbc:ID" />
                  </td>
                  <xsl:if test="//n1:Invoice//cac:InvoiceLine/cac:Item/cbc:BrandName != ''">
                    <td id="lineTableTd" align="center">
                      <xsl:value-of select="./cac:Item/cbc:BrandName" />
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID != 'IHRACAT'">
                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:SellersItemIdentification/cbc:ID != ''">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="./cac:Item/cac:SellersItemIdentification/cbc:ID" />
                      </td>
                    </xsl:if>
                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:BuyersItemIdentification/cbc:ID != ''">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="./cac:Item/cac:BuyersItemIdentification/cbc:ID" />
                      </td>
                    </xsl:if>
                  </xsl:if>
                  <td id="lineTableTd" align="left">
                    <xsl:value-of select="./cac:Item/cbc:Name" />
                  </td>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <xsl:if test="./cac:Delivery/cac:Shipment/cbc:NetWeightMeasure != ''">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="./cac:Delivery/cac:Shipment/cbc:NetWeightMeasure" />
                                     KG
                                 </td>
                    </xsl:if>
                    <xsl:if test="./cac:Delivery/cac:Shipment/cbc:GrossWeightMeasure!= ''">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="./cac:Delivery/cac:Shipment/cbc:GrossWeightMeasure" />
                                     KG
                                 </td>
                    </xsl:if>
                    <xsl:if test="//n1:Invoice/cac:InvoiceLine//cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:Quantity != ''">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="format-number(./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:Quantity, '###.###,####', 'european')" />
                      </td>
                    </xsl:if>
                    <xsl:if test="//n1:Invoice/cac:InvoiceLine//cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode != ''">
                      <td id="lineTableTd" align="center">
                        <xsl:choose>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = '4H'">
                            <xsl:text> P.Cases </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = '5H'">
                            <xsl:text> C.Boxes </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = '6H'">
                            <xsl:text> W.Cases </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'EC'">
                            <xsl:text> P.Bag </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'SA'">
                            <xsl:text> Sack </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'PJ'">
                            <xsl:text> Punnet </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = '8A'">
                            <xsl:text> Pallet </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'PX'">
                            <xsl:text> Pallet </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'DR'">
                            <xsl:text> Drum </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'BK'">
                            <xsl:text> Basket </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'TN'">
                            <xsl:text> Tin </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'CT'">
                            <xsl:text> Carton </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'BE'">
                            <xsl:text> Bundle </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'BG'">
                            <xsl:text> Bag </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'BH'">
                            <xsl:text> Bunch </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'BI'">
                            <xsl:text> Bin </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'BJ'">
                            <xsl:text> Bucket </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'BX'">
                            <xsl:text> Box </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'CB'">
                            <xsl:text> Crate,beer </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'CH'">
                            <xsl:text> Chest </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'CI'">
                            <xsl:text> Canister </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'CK'">
                            <xsl:text> Cask </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'CN'">
                            <xsl:text> Container </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'CR'">
                            <xsl:text> Crate </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'DK'">
                            <xsl:text> Crate,bulk,cardboard </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'DR'">
                            <xsl:text> Drum </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'FC&#xD;&#xA;                                       '">
                            <xsl:text> Crate,Fruit </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'JR'">
                            <xsl:text> Jar </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'LV'">
                            <xsl:text> Liftvan </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'NE'">
                            <xsl:text> Unpacked or Unpackaged </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'SU'">
                            <xsl:text> Suitcase </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode = 'VG'">
                            <xsl:text> Bulk,gas </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode ='VL'">
                            <xsl:text> Bulk,liquid </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode ='VO'">
                            <xsl:text> Bulk,solid </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode ='BA'">
                            <xsl:text> Barrel </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode ='EC'">
                            <xsl:text> Bag,plastic </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode ='5H'">
                            <xsl:text> Bag,woven,plastic </xsl:text>
                          </xsl:when>
                          <xsl:when test="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode ='6H'">
                            <xsl:text> Composite packaging , plastic receptacle </xsl:text>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode/@name" />
                          </xsl:otherwise>
                        </xsl:choose>
                      </td>
                    </xsl:if>
                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cbc:Note != ''">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="./cbc:Note" />
                      </td>
                    </xsl:if>
                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cbc:Description != ''">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="./cac:Item/cbc:Description" />
                      </td>
                    </xsl:if>
                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cbc:ModelName != ''">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="./cac:Item/cbc:ModelName" />
                      </td>
                    </xsl:if>
                  </xsl:if>
                  <td id="lineTableTd" align="center">
                    <xsl:value-of select="format-number(./cbc:InvoicedQuantity, '###.##0,########', 'european')" />
                  </td>
                  <td id="lineTableTd" align="center">
                    <xsl:if test="./cbc:InvoicedQuantity/@unitCode">
                      <xsl:for-each select="./cbc:InvoicedQuantity">
                        <xsl:text>
                        </xsl:text>
                        <xsl:choose>
                          <xsl:when test="@unitCode  = '26'">
                            <xsl:text>Ton</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'BX'">
                            <xsl:text>Kutu</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'LTR'">
                            <xsl:text>Lt</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'C62'">
                            <xsl:text>Adet</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'KGM'">
                            <xsl:text>Kg</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'KJO'">
                            <xsl:text>KJ</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'GRM'">
                            <xsl:text>Gram</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MGM'">
                            <xsl:text>Mg</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'NT'">
                            <xsl:text>Net Ton</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'GT'">
                            <xsl:text>Gross Ton</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MTR'">
                            <xsl:text>M</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MMT'">
                            <xsl:text>Mm</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'KTM'">
                            <xsl:text>Km</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MLT'">
                            <xsl:text>Ml</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MMQ'">
                            <xsl:text>Mm3</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'CLT'">
                            <xsl:text>cl</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'CMK'">
                            <xsl:text>cm2</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'CMQ'">
                            <xsl:text>cm3</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'CMT'">
                            <xsl:text>cm</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MTK'">
                            <xsl:text>m2</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MTQ'">
                            <xsl:text>m3</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'DAY'">
                            <xsl:text> Gün</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MON'">
                            <xsl:text> Ay</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'PA'">
                            <xsl:text> Paket</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'KWH'">
                            <xsl:text> KWH</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'ANN'">
                            <xsl:text> Yıl</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'HUR'">
                            <xsl:text> Saat</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'MIN'">
                            <xsl:text> Dakika</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'SEC'">
                            <xsl:text> Saniye</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'CCT'">
                            <xsl:text> Ton baş.taşıma kap.</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'D30'">
                            <xsl:text> Brüt kalori</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'D40'">
                            <xsl:text> 1000 lt</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'LPA'">
                            <xsl:text> saf alkol lt</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'B32'">
                            <xsl:text> kg.m2</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'NCL'">
                            <xsl:text> hücre adet</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'PR'">
                            <xsl:text> Çift</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'R9'">
                            <xsl:text> 1000 m3</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'SET'">
                            <xsl:text> Set</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'T3'">
                            <xsl:text> 1000 adet</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'SA'">
                            <xsl:text> Sack</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = '5H'">
                            <xsl:text> C.Boxes</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = '4H'">
                            <xsl:text> P.Cases</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'BFT'">
                            <xsl:text> W.Cases</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'EC'">
                            <xsl:text> P.Bag</xsl:text>
                          </xsl:when>
                          <xsl:when test="@unitCode  = 'PJ'">
                            <xsl:text> Punnet</xsl:text>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="@unitCode" />
                          </xsl:otherwise>
                        </xsl:choose>
                      </xsl:for-each>
                    </xsl:if>
                  </td>
                  <td id="lineTableTd" align="center">
                    <xsl:value-of select="format-number(./cac:Price/cbc:PriceAmount, '###.##0,########', 'european')" />
                    <xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID">
                      <xsl:text>
                      </xsl:text>
                      <xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID = &quot;TRY&quot; or ./cac:Price/cbc:PriceAmount/@currencyID = &quot;TRY&quot;">
                        <xsl:text>TL</xsl:text>
                      </xsl:if>
                      <xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID != &quot;TRY&quot; and ./cac:Price/cbc:PriceAmount/@currencyID != &quot;TRY&quot;">
                        <xsl:value-of select="./cac:Price/cbc:PriceAmount/@currencyID" />
                      </xsl:if>
                    </xsl:if>
                  </td>
                  <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge/cbc:Amount != 0">
                    <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:AllowanceCharge/cbc:AllowanceChargeReason !='' ">
                      <td id="lineTableTd" align="center">
                        <xsl:value-of select="./cac:AllowanceCharge/cbc:AllowanceChargeReason" />
                      </td>
                    </xsl:if>
                    <td id="lineTableTd" align="center">
                      <xsl:if test="./cac:AllowanceCharge/cbc:MultiplierFactorNumeric">
                        <xsl:text> %</xsl:text>
                        <xsl:value-of select="format-number(./cac:AllowanceCharge/cbc:MultiplierFactorNumeric * 100, '###.##0,00', 'european')" />
                      </xsl:if>
                    </td>
                    <td id="lineTableTd" align="center">
                      <xsl:for-each select="cac:AllowanceCharge/cbc:Amount">
                        <xsl:call-template name="Curr_Type" />
                      </xsl:for-each>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/n1:Invoice/cac:TaxTotal/cac:TaxSubtotal/cbc:TaxAmount != 0">
                    <td id="lineTableTd" align="center">
                      <xsl:for-each select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
                        <xsl:if test="cbc:TaxTypeCode='0015' ">
                          <xsl:text>
                          </xsl:text>
                          <xsl:if test="../../cbc:Percent">
                            <xsl:text> %</xsl:text>
                            <xsl:value-of select="format-number(../../cbc:Percent, '###.##0,00', 'european')" />
                          </xsl:if>
                        </xsl:if>
                      </xsl:for-each>
                    </td>
                    <td id="lineTableTd" align="center">
                      <xsl:for-each select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
                        <xsl:if test="cbc:TaxTypeCode='0015' ">
                          <xsl:text>
                          </xsl:text>
                          <xsl:for-each select="../../cbc:TaxAmount">
                            <xsl:call-template name="Curr_Type" />
                          </xsl:for-each>
                        </xsl:if>
                      </xsl:for-each>
                    </td>
                  </xsl:if>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <td id="lineTableTd" align="center">
                      <xsl:choose>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '0'">
                          <xsl:text>Transport Mode Not Specified </xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '1'">
                          <xsl:text>BY SHIP</xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '2'">
                          <xsl:text>BY TRAIN</xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '3'">
                          <xsl:text>BY TRUCK</xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '4'">
                          <xsl:text>BY AIRPLANE</xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '5'">
                          <xsl:text>Email</xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '6'">
                          <xsl:text>Multiple Transportation</xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '7'">
                          <xsl:text>Fixed Shipping</xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '8'">
                          <xsl:text>Inland Water Transport</xsl:text>
                        </xsl:when>
                        <xsl:when test="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode = '9'">
                          <xsl:text>Transport Mode Not Available</xsl:text>
                        </xsl:when>
                      </xsl:choose>
                    </td>
                    <td id="lineTableTd" align="center">
                      <xsl:value-of select="./cac:Delivery/cac:Shipment/cac:GoodsItem/cbc:RequiredCustomsID" />
                    </td>
                    <td id="lineTableTd" align="center">
                      <xsl:value-of select="./cac:Delivery/cac:DeliveryTerms/cbc:ID" />
                      <xsl:if test="./cac:Delivery/cac:DeliveryTerms/cbc:SpecialTerms !=''"> 
								 - <xsl:value-of select="./cac:Delivery/cac:DeliveryTerms/cbc:SpecialTerms" /></xsl:if>
                    </td>
                  </xsl:if>
                  <td id="lineTableTd" align="right">
                    <xsl:for-each select="cbc:LineExtensionAmount">
                      <xsl:call-template name="Curr_Type" />
                    </xsl:for-each>
                  </td>
                  <!--  <xsl:if test="./cac:Delivery/cac:Shipment/cbc:InsuranceValueAmount
					                 or ./cac:Delivery/cac:Shipment/cbc:DeclaredForCarriageValueAmount
					                or ./cac:Delivery/cac:Shipment/cbc:FreeOnBoardValueAmount">								
						    <td id="lineTableTd" align="right">							
							<xsl:value-of select="format-number(./cbc:LineExtensionAmount
							+sum(./cac:Delivery/cac:Shipment/cbc:InsuranceValueAmount)
							+sum(./cac:Delivery/cac:Shipment/cbc:DeclaredForCarriageValueAmount)						
							+sum(./cac:Delivery/cac:Shipment/cbc:FreeOnBoardValueAmount)
							, '###.##0,00', 'european')"/>
                              <xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID">
                                 <xsl:text> </xsl:text>
                                 <xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID = &quot;TRY&quot; or ./cac:Price/cbc:PriceAmount/@currencyID = &quot;TRY&quot;">
                                    <xsl:text>TL</xsl:text>
                                 </xsl:if>
                                 <xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID != &quot;TRY&quot; and ./cac:Price/cbc:PriceAmount/@currencyID != &quot;TRY&quot;">
                                    <xsl:value-of select="./cac:Price/cbc:PriceAmount/@currencyID"/>
                                 </xsl:if>
                              </xsl:if>
                            </td>							 
						 </xsl:if> -->
                </tr>
              </xsl:for-each>
            </tbody>
          </table>
        </xsl:for-each>
        <table id="budgetContainerTable" style="margin-left:320px;" width="480px">
          <xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
            <xsl:if test="cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode = '4171'">
              <tr id="budgetContainerTr" align="right">
                <td id="budgetContainerDummyTd" />
                <td id="lineTableBudgetTd" align="right" width="210px">
                  <span style="font-weight:bold;color:#005087;color:#005087;">
                    <xsl:text>Teslim Bedeli</xsl:text>
                  </span>
                </td>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                  <td id="lineTableBudgetTd" align="left" width="180px">
                    <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                      <xsl:text>  Delivery Price</xsl:text>
                    </span>
                  </td>
                </xsl:if>
                <td id="lineTableBudgetTd" style="width:90px; " align="right">
                  <xsl:for-each select="n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount">
                    <xsl:call-template name="Curr_Type" />
                  </xsl:for-each>
                </td>
              </tr>
            </xsl:if>
          </xsl:for-each>
          <tr id="budgetContainerTr" align="right">
            <td id="budgetContainerDummyTd" />
            <td id="lineTableBudgetTd" align="right" width="210px">
              <span style="font-weight:bold;color:#005087;">
                <xsl:text>Mal/Hizmet Toplam Tutarı</xsl:text>
              </span>
            </td>
            <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
              <td id="lineTableBudgetTd" align="left" width="180px">
                <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                  <xsl:text>  Goods/Service Total Amount</xsl:text>
                </span>
              </td>
            </xsl:if>
            <td id="lineTableBudgetTd" style="width:90px; " align="right">
              <xsl:for-each select="n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount">
                <xsl:call-template name="Curr_Type" />
              </xsl:for-each>
            </td>
          </tr>
          <xsl:if test="n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount !=0">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" align="right" width="210px">
                <span style="font-weight:bold;color:#005087;">
                  <xsl:text>Toplam İskonto</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" align="left" width="180px">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Total Discount</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:for-each select="n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount">
                  <xsl:call-template name="Curr_Type" />
                </xsl:for-each>
              </td>
            </tr>
          </xsl:if>
          <xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold;color:#005087; ">
                  <xsl:text>Matrah </xsl:text>
                  <xsl:text>(%</xsl:text>
                  <xsl:value-of select="cbc:Percent" />
                  <xsl:text>)</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Tax Percent</xsl:text>
                    <xsl:text>(</xsl:text>
                    <xsl:value-of select="cbc:Percent" />
                    <xsl:text>%)</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:for-each select="cac:TaxCategory/cac:TaxScheme">
                  <xsl:text>
                  </xsl:text>
                  <xsl:value-of select="format-number(../../cbc:TaxableAmount, '###.##0,00', 'european')" />
                  <xsl:if test="../../cbc:TaxAmount/@currencyID">
                    <xsl:text>
                    </xsl:text>
                    <xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL' or ../../cbc:TaxAmount/@currencyID = 'TRY'">
                      <xsl:text>TL</xsl:text>
                    </xsl:if>
                    <xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL' and ../../cbc:TaxAmount/@currencyID != 'TRY'">
                      <xsl:value-of select="../../cbc:TaxAmount/@currencyID" />
                    </xsl:if>
                  </xsl:if>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
          <xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold;color:#005087; ">
                  <xsl:text>Hesaplanan </xsl:text>
                  <xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name" />
                  <xsl:text>(%</xsl:text>
                  <xsl:value-of select="cbc:Percent" />
                  <xsl:text>)</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Tax Percent</xsl:text>
                    <xsl:text>(</xsl:text>
                    <xsl:value-of select="cbc:Percent" />
                    <xsl:text>%)</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:for-each select="cac:TaxCategory/cac:TaxScheme">
                  <xsl:text>
                  </xsl:text>
                  <xsl:value-of select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')" />
                  <xsl:if test="../../cbc:TaxAmount/@currencyID">
                    <xsl:text>
                    </xsl:text>
                    <xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL' or ../../cbc:TaxAmount/@currencyID = 'TRY'">
                      <xsl:text>TL</xsl:text>
                    </xsl:if>
                    <xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL' and ../../cbc:TaxAmount/@currencyID != 'TRY'">
                      <xsl:value-of select="../../cbc:TaxAmount/@currencyID" />
                    </xsl:if>
                  </xsl:if>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
          <xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
            <xsl:if test="cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode = '4171'">
              <tr id="budgetContainerTr" align="right">
                <td id="budgetContainerDummyTd" />
                <td id="lineTableBudgetTd" align="right" width="210px">
                  <span style="font-weight:bold; color:#005087;">
                    <xsl:text>KDV Matrahı</xsl:text>
                  </span>
                </td>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                  <td id="lineTableBudgetTd" align="left" width="180px">
                    <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                      <xsl:text>  VAT Basis</xsl:text>
                    </span>
                  </td>
                </xsl:if>
                <td id="lineTableBudgetTd" style="width:90px; " align="right">
                  <xsl:value-of select="format-number(sum(//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=0015]/cbc:TaxableAmount), '###.##0,00', 'european')" />
                  <xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID">
                    <xsl:text>
                    </xsl:text>
                    <xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRL' or //n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRY'">
                      <xsl:text>TL</xsl:text>
                    </xsl:if>
                    <xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRY'">
                      <xsl:value-of select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID" />
                    </xsl:if>
                  </xsl:if>
                </td>
              </tr>
              <tr id="budgetContainerTr" align="right">
                <td id="budgetContainerDummyTd" />
                <td id="lineTableBudgetTd" align="right" width="210px">
                  <span style="font-weight:bold; color:#005087;">
                    <xsl:text>Tevkifat Dahil Toplam Tutar</xsl:text>
                  </span>
                </td>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                  <td id="lineTableBudgetTd" align="left" width="180px">
                    <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                      <xsl:text>  Total Amount Including Withholding</xsl:text>
                    </span>
                  </td>
                </xsl:if>
                <td id="lineTableBudgetTd" style="width:90px; " align="right">
                  <xsl:for-each select="n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount">
                    <xsl:call-template name="Curr_Type" />
                  </xsl:for-each>
                </td>
              </tr>
              <tr id="budgetContainerTr" align="right">
                <td id="budgetContainerDummyTd" />
                <td id="lineTableBudgetTd" align="right" width="210px">
                  <span style="font-weight:bold; color:#005087;">
                    <xsl:text>Tevkifat Hariç Toplam Tutar</xsl:text>
                  </span>
                </td>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                  <td id="lineTableBudgetTd" align="left" width="180px">
                    <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                      <xsl:text>  Total Amount Excluding Withholding</xsl:text>
                    </span>
                  </td>
                </xsl:if>
                <td id="lineTableBudgetTd" style="width:90px; " align="right">
                  <xsl:for-each select="n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount">
                    <xsl:call-template name="Curr_Type" />
                  </xsl:for-each>
                </td>
              </tr>
            </xsl:if>
          </xsl:for-each>
          <xsl:for-each select="n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Hesaplanan KDV Tevkifat</xsl:text>
                  <xsl:text>(%</xsl:text>
                  <xsl:value-of select="cbc:Percent" />
                  <xsl:text>)</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Reverse Charge Output VAT </xsl:text>
                    <xsl:text>(</xsl:text>
                    <xsl:value-of select="cbc:Percent" />
                    <xsl:text>%)</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:for-each select="cac:TaxCategory/cac:TaxScheme">
                  <xsl:text>
                  </xsl:text>
                  <xsl:value-of select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')" />
                  <xsl:if test="../../cbc:TaxAmount/@currencyID">
                    <xsl:text>
                    </xsl:text>
                    <xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRL' or ../../cbc:TaxAmount/@currencyID = 'TRY'">
                      <xsl:text>TL</xsl:text>
                    </xsl:if>
                    <xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRL' and ../../cbc:TaxAmount/@currencyID != 'TRY'">
                      <xsl:value-of select="../../cbc:TaxAmount/@currencyID" />
                    </xsl:if>
                  </xsl:if>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
          <xsl:if test="sum(n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:TaxableAmount)&gt;0">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Tevkifata Tabi İşlem Tutarı</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Amount Subject To Withholding</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:value-of select="format-number(sum(n1:Invoice/cac:InvoiceLine[cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:LineExtensionAmount), '###.##0,00', 'european')" />
                <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
                  <xsl:text>TL</xsl:text>
                </xsl:if>
                <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
                  <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode" />
                </xsl:if>
              </td>
            </tr>
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Tevkifata Tabi İşlem Üzerinden Hes. KDV</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Output VAT Of The Transaction Subject To Withholding</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:value-of select="format-number(sum(n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:TaxableAmount), '###.##0,00', 'european')" />
                <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL'">
                  <xsl:text>TL</xsl:text>
                </xsl:if>
                <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
                  <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode" />
                </xsl:if>
              </td>
            </tr>
          </xsl:if>
          <xsl:if test="n1:Invoice/cac:InvoiceLine[cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme]">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Tevkifata Tabi İşlem Tutarı</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Amount Subject To Withholding</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:if test="n1:Invoice/cac:InvoiceLine[cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme]">
                  <xsl:value-of select="format-number(sum(n1:Invoice/cac:InvoiceLine[cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme]/cbc:LineExtensionAmount), '###.##0,00', 'european')" />
                </xsl:if>
                <xsl:if test="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode='9015'">
                  <xsl:value-of select="format-number(sum(n1:Invoice/cac:InvoiceLine[cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:LineExtensionAmount), '###.##0,00', 'european')" />
                </xsl:if>
                <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL' or n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
                  <xsl:text>TL</xsl:text>
                </xsl:if>
                <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL' and n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
                  <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode" />
                </xsl:if>
              </td>
            </tr>
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Tevkifata Tabi İşlem Üzerinden Hes. KDV</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Amount Subject To Withholding</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:if test="n1:Invoice/cac:InvoiceLine[cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme]">
                  <xsl:value-of select="format-number(sum(n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme]/cbc:TaxableAmount), '###.##0,00', 'european')" />
                </xsl:if>
                <xsl:if test="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode='9015'">
                  <xsl:value-of select="format-number(sum(n1:Invoice/cac:TaxTotal/cac:TaxSubtotal[cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode=9015]/cbc:TaxableAmount), '###.##0,00', 'european')" />
                </xsl:if>
                <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL' or n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
                  <xsl:text>TL</xsl:text>
                </xsl:if>
                <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL' and n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
                  <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode" />
                </xsl:if>
              </td>
            </tr>
          </xsl:if>
          <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:InsuranceValueAmount">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Sigorta Tutarı</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Insurance Total</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:value-of select="format-number(sum(//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:InsuranceValueAmount), '###.##0,00', 'european')" />
                <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
                  <xsl:text> TL</xsl:text>
                </xsl:if>
                <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
                  <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode" />
                </xsl:if>
              </td>
            </tr>
          </xsl:if>
          <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:DeclaredForCarriageValueAmount">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Navlun Tutarı</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Freight Total</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:value-of select="format-number(sum(//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:DeclaredForCarriageValueAmount), '###.##0,00', 'european')" />
                <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
                  <xsl:text> TL</xsl:text>
                </xsl:if>
                <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
                  <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode" />
                </xsl:if>
              </td>
            </tr>
          </xsl:if>
          <xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:FreeOnBoardValueAmount">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:value-of select="substring-before(substring-after(.,'#AÇIKLAMA:'),'~;')" />
                </span>
              </td>
              <td id="lineTableBudgetTd" width="180px" align="left">
                <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                </span>
              </td>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:value-of select="format-number(sum(//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:Shipment/cbc:FreeOnBoardValueAmount), '###.##0,00', 'european')" />
                <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRL' or //n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
                  <xsl:text> TL</xsl:text>
                </xsl:if>
                <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRL' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
                  <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode" />
                </xsl:if>
              </td>
            </tr>
          </xsl:if>
          <!-- <xsl:if test="contains(.,'#NAVLUN:')">
                  <tr id="budgetContainerTr" align="right">
                     <td id="budgetContainerDummyTd"/>
                     <td id="lineTableBudgetTd" width="210px" align="right">
                        <span style="font-weight:bold; color:#005087;">
                           <xsl:text>Navlun Tutarı</xsl:text>
                        </span>
                     </td>
                     <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <td id="lineTableBudgetTd" width="180px" align="left">
                           <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <xsl:text>&#160;&#160;Freight Total</xsl:text>
                           </span>
                        </td>
                     </xsl:if>
                     <td id="lineTableBudgetTd" style="width:90px; " align="right">
                        <xsl:value-of select="substring-before(substring-after(.,'#NAVLUN:'),'~;')"/>
                        &#160;
                        <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL' or n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
                           <xsl:text>TL</xsl:text>
                        </xsl:if>
                        <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL' and n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
                           <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
                        </xsl:if>
                     </td>
                  </tr>
               </xsl:if>-->
          <!-- <xsl:if test="contains(.,'#SIGORTA:')">
                  <tr id="budgetContainerTr" align="right">
                     <td id="budgetContainerDummyTd"/>
                     <td id="lineTableBudgetTd" width="210px" align="right">
                        <span style="font-weight:bold; color:#005087;">
                           <xsl:text>Sigorta Tutarı</xsl:text>
                        </span>
                     </td>
                     <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                        <td id="lineTableBudgetTd" width="180px" align="left">
                           <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                              <xsl:text>&#160;&#160;Insurance Total</xsl:text>
                           </span>
                        </td>
                     </xsl:if>
                     <td id="lineTableBudgetTd" style="width:90px; " align="right">
                        <xsl:value-of select="substring-before(substring-after(.,'#SIGORTA:'),'~;')"/>
                        &#160;
                        <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode = 'TRL' or n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
                           <xsl:text>TL</xsl:text>
                        </xsl:if>
                        <xsl:if test="n1:Invoice/cbc:DocumentCurrencyCode != 'TRL' and n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
                           <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode"/>
                        </xsl:if>
                     </td>
                  </tr>
               </xsl:if> -->
          <xsl:if test="//n1:Invoice/cbc:ProfileID != 'IHRACAT'">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Vergiler Dahil Toplam Tutar</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Total Amount Including Taxes</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:for-each select="n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount">
                  <xsl:call-template name="Curr_Type" />
                </xsl:for-each>
              </td>
            </tr>
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>Ödenecek Tutar</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Amount To Be Paid</xsl:text>
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:for-each select="n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount">
                  <xsl:call-template name="Curr_Type" />
                </xsl:for-each>
              </td>
            </tr>
            <xsl:for-each select="n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
              <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY' and //n1:Invoice/cbc:DocumentCurrencyCode != 'TRL'">
                <tr align="right">
                  <td />
                  <td id="lineTableBudgetTd" width="210px" align="right">
                    <span style="font-weight:bold; color:#005087;">
                      <xsl:text>Döviz Kuru</xsl:text>
                    </span>
                  </td>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <td id="lineTableBudgetTd" width="180px" align="left">
                      <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                        <xsl:text>  Exchange Rate</xsl:text>
                      </span>
                    </td>
                  </xsl:if>
                  <td id="lineTableBudgetTd" style="width:90px; " align="right">
                    <xsl:value-of select="format-number(//n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,0000', 'european')" />
                    <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode = 'TRY'">
                      <xsl:text> TL</xsl:text>
                    </xsl:if>
                    <xsl:if test="//n1:Invoice/cbc:DocumentCurrencyCode != 'TRY'">
                                  
                                 <xsl:value-of select="//n1:Invoice/cbc:DocumentCurrencyCode" /></xsl:if>
                  </td>
                </tr>
                <tr align="right">
                  <td />
                  <td id="lineTableBudgetTd" align="right" width="210px">
                    <span style="font-weight:bold; color:#005087;">
                      <xsl:text>Mal Hizmet Toplam Tutarı(TL)</xsl:text>
                    </span>
                  </td>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <td id="lineTableBudgetTd" align="left" width="180px">
                      <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                        <xsl:text>  Goods/Service Total Amount(TL)</xsl:text>
                      </span>
                    </td>
                  </xsl:if>
                  <td id="lineTableBudgetTd" style="width:90px; " align="right">
                    <xsl:value-of select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount * //n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')" />
                    <xsl:text> TL</xsl:text>
                  </td>
                </tr>
                <tr align="right">
                  <td />
                  <td id="lineTableBudgetTd" align="right" width="210px">
                    <span style="font-weight:bold; color:#005087;">
                      <xsl:text>Matrah </xsl:text>
                      <xsl:text>(%</xsl:text>
                      <xsl:value-of select="cbc:Percent" />
                      <xsl:text>) (TL)</xsl:text>
                    </span>
                  </td>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <td id="lineTableBudgetTd" align="left" width="180px">
                      <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                        <xsl:text>  Tax Percent</xsl:text>
                        <xsl:text>(</xsl:text>
                        <xsl:value-of select="cbc:Percent" />
                        <xsl:text>%) (TL)</xsl:text>
                      </span>
                    </td>
                  </xsl:if>
                  <td id="lineTableBudgetTd" style="width:90px; " align="right">
                    <span>
                      <xsl:value-of select="format-number(cbc:TaxableAmount * //n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')" />
                      <xsl:text> TL</xsl:text>
                    </span>
                  </td>
                </tr>
                <tr align="right">
                  <td />
                  <td id="lineTableBudgetTd" align="right" width="210px">
                    <span style="font-weight:bold; color:#005087;">
                      <xsl:text>Hesaplanan </xsl:text>
                      <xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name" />
                      <xsl:text>(%</xsl:text>
                      <xsl:value-of select="cbc:Percent" />
                      <xsl:text>) (TL)</xsl:text>
                    </span>
                  </td>
                  <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                    <td id="lineTableBudgetTd" align="left" width="180px">
                      <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                        <xsl:text>  Tax Percent</xsl:text>
                        <xsl:text>(</xsl:text>
                        <xsl:value-of select="cbc:Percent" />
                        <xsl:text>%) (TL)</xsl:text>
                      </span>
                    </td>
                  </xsl:if>
                  <td id="lineTableBudgetTd" style="width:90px; " align="right">
                    <span>
                      <xsl:value-of select="format-number(cbc:TaxAmount * //n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')" />
                      <xsl:text> TL</xsl:text>
                    </span>
                  </td>
                </tr>
              </xsl:if>
            </xsl:for-each>
            <xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRL' and //n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRY'">
              <tr id="budgetContainerTr" align="right">
                <td />
                <td id="lineTableBudgetTd" width="210px" align="right">
                  <span style="font-weight:bold; color:#005087;">
                    <xsl:text>Vergiler Dahil Toplam Tutar(TL)</xsl:text>
                  </span>
                </td>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                  <td id="lineTableBudgetTd" width="180px" align="left">
                    <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                      <xsl:text>  Total Amount Including Taxes(TL)</xsl:text>
                    </span>
                  </td>
                </xsl:if>
                <td id="lineTableBudgetTd" style="width:90px; " align="right">
                  <xsl:value-of select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount * //n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')" />
                  <xsl:text> TL</xsl:text>
                </td>
              </tr>
              <tr align="right">
                <td />
                <td id="lineTableBudgetTd" width="210px" align="right">
                  <span style="font-weight:bold; color:#005087;">
                    <xsl:text>Ödenecek Tutar(TL)</xsl:text>
                  </span>
                </td>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                  <td id="lineTableBudgetTd" width="180px" align="left">
                    <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                      <xsl:text>  Amount To Be Paid(TL)</xsl:text>
                    </span>
                  </td>
                </xsl:if>
                <td id="lineTableBudgetTd" style="width:90px; " align="right">
                  <xsl:value-of select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount * //n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')" />
                  <xsl:text> TL</xsl:text>
                </td>
              </tr>
            </xsl:if>
          </xsl:if>
          <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
            <tr id="budgetContainerTr" align="right">
              <td id="budgetContainerDummyTd" />
              <td id="lineTableBudgetTd" width="210px" align="right">
                <span style="font-weight:bold; color:#005087;">
                  <xsl:text>  Toplam Tutar</xsl:text>
                </span>
              </td>
              <xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
                <td id="lineTableBudgetTd" width="180px" align="left">
                  <span style="font-size:10px;font-style:italic;color:#808080;font-family: Arial, Helvetica, sans-serif;">
                    <xsl:text>  Total </xsl:text>
                    <xsl:value-of select="//n1:Invoice/cac:InvoiceLine/cac:Delivery/cac:DeliveryTerms/cbc:ID" />
                  </span>
                </td>
              </xsl:if>
              <td id="lineTableBudgetTd" style="width:90px; " align="right">
                <xsl:for-each select="n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount">
                  <xsl:call-template name="Curr_Type" />
                </xsl:for-each>
              </td>
            </tr>
          </xsl:if>
        </table>
        <xsl:if test="//n1:Invoice/cbc:InvoiceTypeCode = 'SGK'">
          <table border="1" width="250px" style="font-size: 10px; font-weight: bold">
            <tr>
              <td>İlave Fatura Tipi</td>
              <td>
                <xsl:value-of select="//n1:Invoice/cbc:AccountingCost" />
              </td>
            </tr>
            <xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
              <xsl:if test="cbc:DocumentTypeCode = 'MUKELLEF_KODU'">
                <tr>
                  <td>
                    <xsl:value-of select="cbc:DocumentDescription" />
                  </td>
                  <td>
                    <xsl:value-of select="cbc:DocumentType" />
                  </td>
                </tr>
              </xsl:if>
            </xsl:for-each>
            <xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
              <xsl:if test="cbc:DocumentTypeCode = 'MUKELLEF_ADI'">
                <tr>
                  <td>
                    <xsl:value-of select="cbc:DocumentDescription" />
                  </td>
                  <td>
                    <xsl:value-of select="cbc:DocumentType" />
                  </td>
                </tr>
              </xsl:if>
            </xsl:for-each>
            <xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
              <xsl:if test="cbc:DocumentTypeCode = 'DOSYA_NO'">
                <tr>
                  <td>
                    <xsl:value-of select="cbc:DocumentDescription" />
                  </td>
                  <td>
                    <xsl:value-of select="cbc:DocumentType" />
                  </td>
                </tr>
              </xsl:if>
            </xsl:for-each>
            <xsl:if test="//n1:Invoice/cac:InvoicePeriod">
              <td colspan="2">
                     Dönem :  <xsl:value-of select="//n1:Invoice/cac:InvoicePeriod/cbc:StartDate" />  |  <xsl:value-of select="//n1:Invoice/cac:InvoicePeriod/cbc:EndDate" /></td>
            </xsl:if>
          </table>
        </xsl:if>
        <table id="notesTable" width="800px" height="100">
          <tbody>
            <tr align="left">
              <td id="notesTableTd">
                <xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
                  <xsl:if test="cbc:Percent=0 and cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode='0015'">
                    <b>      Vergi İstisna Muafiyet
                              Sebebi: </b>
                    <xsl:value-of select="cac:TaxCategory/cbc:TaxExemptionReason" />
                    <br />
                  </xsl:if>
                </xsl:for-each>
                <xsl:for-each select="//n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
                  <b>   Tevkifat Sebebi: </b>
                  <xsl:value-of select="cbc:TaxTypeCode" />
                  <xsl:text>-</xsl:text>
                  <xsl:value-of select="cbc:Name" />
                  <br />
                </xsl:for-each>
                <xsl:if test="//n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate !=0">
                  <b>
                                   
                              <xsl:value-of select="n1:Invoice/cbc:DocumentCurrencyCode" />
                              Döviz Kuru: 
                           </b>
                  <xsl:value-of select="format-number(//n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,0000', 'european')" />
                  <br />
                </xsl:if>
                <!--<xsl:if test="//n1:Invoice/cbc:Note">-->
                <b>
                </b>
                <xsl:for-each select="//n1:Invoice/cbc:Note">
                  <xsl:if test="not(contains(.,'#GTB_REFNO:'))">
                    <xsl:if test="not(contains(.,'#AÇIKLAMA:'))">
                      <xsl:if test="not(contains(.,'#NAVLUN:'))">
                        <xsl:if test="not(contains(.,'#SIGORTA:'))">
                          <xsl:if test=".">
                            <b>     </b>
                            <xsl:value-of select="." />
                            <br />
                          </xsl:if>
                        </xsl:if>
                      </xsl:if>
                    </xsl:if>
                  </xsl:if>
                </xsl:for-each>
                <!--Sabit Notlar-->
                <b>     </b>
                <br />
                <!--</xsl:if>-->
                <xsl:if test="//n1:Invoice/cac:PaymentMeans/cbc:InstructionNote">
                  <b>      Ödeme Notu: </b>
                  <xsl:value-of select="//n1:Invoice/cac:PaymentMeans/cbc:InstructionNote" />
                  <br />
                </xsl:if>
                <xsl:if test="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:PaymentNote">
                  <b>      Hesap Açıklaması: </b>
                  <xsl:value-of select="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:PaymentNote" />
                  <br />
                </xsl:if>
                <xsl:if test="//n1:Invoice/cac:PaymentTerms/cbc:Note">
                  <b>      Ödeme Koşulu: </b>
                  <xsl:value-of select="//n1:Invoice/cac:PaymentTerms/cbc:Note" />
                  <br />
                </xsl:if>
                <xsl:if test="//n1:Invoice/cac:BillingReference/cac:InvoiceDocumentReference/cbc:ID">
                  <b>      İade Fatura No: </b>
                  <xsl:value-of select="//n1:Invoice/cac:BillingReference/cac:InvoiceDocumentReference/cbc:ID" />
                  <br />
                  <b>      İade Fatura Tarih: </b>
                  <xsl:value-of select="//n1:Invoice/cac:BillingReference/cac:InvoiceDocumentReference/cbc:IssueDate" />
                  <br />
                </xsl:if>
                <xsl:if test="//n1:Invoice/cbc:ProfileID = 'EARSIVFATURA'">
                  <xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
                    <xsl:if test="cbc:ID = 'IsInternetSale' and cbc:DocumentType = 'true'">
                      <table class="eArchiveDetailTable" id="lineTable" width="800" height="50" border="1px">
                        <tr align="center">
                          <td style="font-weight:bold; color:#005087;" colspan="2">
                            <b>DİĞER DETAY BİLGİLER</b>
                          </td>
                        </tr>
                        <tr>
                          <td style="font-weight:bold; color:#005087;"> <b>Web Sitesi:</b></td>
                          <td>
                                           
                                          <xsl:value-of select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cbc:WebsiteURI" /></td>
                        </tr>
                        <tr>
                          <td style="font-weight:bold; color:#005087;"> <b>Ödeme Şekli:</b></td>
                          <td>
                            <xsl:for-each select="//n1:Invoice/cac:PaymentMeans">
                              <xsl:if test="cbc:PaymentMeansCode = 1"> ODEMEARACISI</xsl:if>
                              <xsl:if test="cbc:PaymentMeansCode = 10"> KAPIDAODEME</xsl:if>
                              <xsl:if test="cbc:PaymentMeansCode = 30"> EFT/HAVALE</xsl:if>
                              <xsl:if test="cbc:PaymentMeansCode = 48"> KREDIKARTI/BANKAKARTI</xsl:if>
                              <xsl:if test="cbc:PaymentMeansCode = 97">
                                                 DIGER - 
                                                <xsl:value-of select="cbc:InstructionNote" /></xsl:if>
                            </xsl:for-each>
                          </td>
                        </tr>
                        <tr>
                          <td style="font-weight:bold; color:#005087;"> <b>Ödeme Tarihi:</b></td>
                          <td>
                            <xsl:for-each select="//n1:Invoice/cac:PaymentMeans/cbc:PaymentDueDate">
                                              
                                             <xsl:apply-templates select="." /></xsl:for-each>
                          </td>
                        </tr>
                        <xsl:if test="//n1:Invoice/cac:Delivery/cac:CarrierParty/cac:PartyIdentification/cbc:ID[@schemeID='TCKN']">
                          <tr>
                            <td style="font-weight:bold; color:#005087;"> <b>Gönderi Taşıyıcı TCKN:</b></td>
                            <td>
                                              
                                             <xsl:value-of select="//n1:Invoice/cac:Delivery/cac:CarrierParty/cac:PartyIdentification/cbc:ID[@schemeID='TCKN']" /></td>
                          </tr>
                          <tr>
                            <td style="font-weight:bold; color:#005087;"> <b>Gönderi Taşıyıcı Adı / Soyadı:</b></td>
                            <td>
                                              
                                             <xsl:value-of select="//n1:Invoice/cac:Delivery/cac:CarrierParty/cac:Person/cbc:FirstName" />
                                              
                                             <xsl:value-of select="//n1:Invoice/cac:Delivery/cac:CarrierParty/cac:Person/cbc:FamilyName" /></td>
                          </tr>
                        </xsl:if>
                        <xsl:if test="//n1:Invoice/cac:Delivery/cac:CarrierParty/cac:PartyIdentification/cbc:ID[@schemeID='VKN']">
                          <tr>
                            <td style="font-weight:bold; color:#005087;"> <b>Gönderi Taşıyıcı VKN:</b></td>
                            <td>
                                              
                                             <xsl:value-of select="//n1:Invoice/cac:Delivery/cac:CarrierParty/cac:PartyIdentification/cbc:ID[@schemeID='VKN']" /></td>
                          </tr>
                          <tr>
                            <td style="font-weight:bold; color:#005087;"> <b>Gönderi Taşıyıcı Ünvanı:</b></td>
                            <td>
                                              
                                             <xsl:value-of select="//n1:Invoice/cac:Delivery/cac:CarrierParty/cac:PartyName/cbc:Name" /></td>
                          </tr>
                        </xsl:if>
                        <tr>
                          <td style="font-weight:bold; color:#005087;"> <b>Gönderim / Hizmet İfa Tarihi:</b></td>
                          <td>
                            <xsl:for-each select="//n1:Invoice/cac:Delivery/cac:Despatch/cbc:ActualDespatchDate">
                                              
                                             <xsl:apply-templates select="." /></xsl:for-each>
                          </td>
                        </tr>
                      </table>
                    </xsl:if>
                  </xsl:for-each>
                  <table class="eArchiveTable" id="lineTable" width="800" height="50">
                    <tbody>
                      <tr align="left">
                        <td>
                          <b>   e-Arşiv İzni Kapsamında Üretilmiştir.</b>
                        </td>
                      </tr>
                      <xsl:if test="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID='HideDespatchMessage']">
                        <xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
                          <xsl:if test="cbc:ID = 'HideDespatchMessage' and cbc:DocumentType = 'false'">
                            <xsl:if test="not(//n1:Invoice/cac:DespatchDocumentReference/cbc:ID and //n1:Invoice/cac:DespatchDocumentReference/cbc:IssueDate)">
                              <tr align="left">
                                <td>
                                  <b>  İrsaliye yerine geçer. </b>
                                </td>
                              </tr>
                            </xsl:if>
                          </xsl:if>
                        </xsl:for-each>
                      </xsl:if>
                      <xsl:if test="not(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID='HideDespatchMessage'])">
                        <xsl:if test="not(//n1:Invoice/cac:DespatchDocumentReference/cbc:ID and //n1:Invoice/cac:DespatchDocumentReference/cbc:IssueDate)">
                          <tr align="left">
                            <td>
                              <b>  İrsaliye yerine geçer. </b>
                            </td>
                          </tr>
                        </xsl:if>
                      </xsl:if>
                      <xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
                        <xsl:if test="cbc:ID = 'IsInternetSale' and cbc:DocumentType = 'true'">
                          <tr align="left">
                            <td>
                              <b>  Bu satış internet üzerinden yapılmıştır.</b>
                            </td>
                          </tr>
                        </xsl:if>
                      </xsl:for-each>
                      <xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
                        <xsl:if test="cbc:ID = 'SendType' and cbc:DocumentType = 'ELEKTRONIK'">
                          <tr align="left">
                            <td>
                              <b>  e-Arşiv izni kapsamında elektronik ortamda iletilmiştir.</b>
                            </td>
                          </tr>
                        </xsl:if>
                      </xsl:for-each>
                    </tbody>
                  </table>
                  <xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
                    <xsl:if test="cbc:ID = 'IsInternetSale' and cbc:DocumentType = 'true'">
                      <table class="eArchiveReturnTable" id="lineTable" width="800" height="50" border="1px">
                        <tbody>
                          <tr align="center">
                            <td style="font-weight:bold; color:#005087;">
                              <b>İADE BÖLÜMÜ</b>
                              <br />
                            </td>
                          </tr>
                          <tr align="left">
                            <td style="font-weight:bold; color:#005087;">
                              <b>      <u>İade Edenin;</u></b>
                              <br />
                              <b>      Adı Soyadı:</b>
                              <br />
                              <b>      Adresi:</b>
                              <br />
                              <b>      İmza:</b>
                              <br />
                            </td>
                          </tr>
                          <tr style="font-weight:bold; color:#005087;" align="left">
                            <td style="font-weight:bold; color:#005087;">
                              <table width="100%" align="center" border="1px">
                                <tbody>
                                  <tr style="font-weight:bold; color:#005087;" align="center" height="20">
                                    <td>
                                      <b>İade Edilen Malın Cinsi</b>
                                    </td>
                                    <td>
                                      <b>Miktar</b>
                                    </td>
                                    <td>
                                      <b>Birim Fiyat</b>
                                    </td>
                                    <td>
                                      <b>Tutar</b>
                                    </td>
                                  </tr>
                                  <tr align="center">
                                    <td> </td>
                                    <td> </td>
                                    <td> </td>
                                    <td> </td>
                                  </tr>
                                  <tr align="center">
                                    <td> </td>
                                    <td> </td>
                                    <td> </td>
                                    <td> </td>
                                  </tr>
                                </tbody>
                              </table>
                            </td>
                          </tr>
                        </tbody>
                      </table>
                    </xsl:if>
                  </xsl:for-each>
                </xsl:if>
                <table border="1" width="800px" id="bankingTable" style="font-size: 10px; font-weight: bold">
                  <caption style="text-align: left; padding: px">
                  </caption>
                  <tr>
                    <th style="width:100px" align="left">BANKA ADI</th>
                    <th style="width:100px" align="left">HESAP NO</th>
                    <th style="width:100px" align="left">IBAN</th>
                    <th style="width:100px" align="left">ŞUBE ADI</th>
                  </tr>
                  <tr>
                    <td>    YAPI KREDİ BANKASI </td>
                    <td>52562044</td>
                    <td>TR23 0006 7010 0000 0052 5620 44</td>
                    <td>KURTTEPE ŞUBESİ</td>
                  </tr>
                  <tr>
                    <td>  AKBANK </td>
                    <td>0084307</td>
                    <td>TR76 0004 6003 3688 8000 0843 07</td>
                    <td>YENİ ADANA </td>
                  </tr>
                </table>
              </td>
            </tr>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="//cbc:IssueDate">
    <xsl:value-of select="substring(.,9,2)" />
      -
      <xsl:value-of select="substring(.,6,2)" />
      -
      <xsl:value-of select="substring(.,1,4)" /></xsl:template>
  <xsl:template match="//n1:Invoice">
    <tr id="lineTableTr">
      <td id="lineTableTd">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd" align="right">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd" align="right">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd" align="right">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd" align="right">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd" align="right">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd" align="right">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd" align="right">
        <xsl:text> </xsl:text>
      </td>
      <td id="lineTableTd" align="right">
        <xsl:text> </xsl:text>
      </td>
    </tr>
  </xsl:template>
  <xsl:template name="Party_Title">
    <xsl:param name="PartyType" />
    <td style="width:469px; " align="left">
      <xsl:if test="cac:PartyName">
        <b>
          <xsl:value-of select="cac:PartyName/cbc:Name" />
        </b>
      </xsl:if>
      <!-- <xsl:for-each select="cac:Person">
            <xsl:for-each select="cbc:Title">
               <xsl:apply-templates/>
               <xsl:text>&#160;</xsl:text>
            </xsl:for-each>
            <xsl:for-each select="cbc:FirstName">
               <xsl:apply-templates/>
               <xsl:text>&#160;</xsl:text>
            </xsl:for-each>
            <xsl:for-each select="cbc:MiddleName">
               <xsl:apply-templates/>
               <xsl:text>&#160; </xsl:text>
            </xsl:for-each>
            <xsl:for-each select="cbc:FamilyName">
               <xsl:apply-templates/>
               <xsl:text>&#160;</xsl:text>
            </xsl:for-each>
            <xsl:for-each select="cbc:NameSuffix">
               <xsl:apply-templates/>
            </xsl:for-each>
            <xsl:if test="$PartyType='TAXFREE'">
               <br/>
               <xsl:text>Pasaport No: </xsl:text>
               <xsl:value-of select="cac:IdentityDocumentReference/cbc:ID"/>
               <br/>
               <xsl:text>Ülkesi: </xsl:text>
               <xsl:value-of select="cbc:NationalityID"/>
            </xsl:if>
         </xsl:for-each> -->
    </td>
  </xsl:template>
  <xsl:template name="Party_Adress">
    <xsl:param name="PartyType" />
    <td style="width:469px; " align="left">
      <xsl:for-each select="cac:PostalAddress">
        <xsl:for-each select="cbc:StreetName">
          <xsl:apply-templates />
          <xsl:text> </xsl:text>
        </xsl:for-each>
        <xsl:for-each select="cbc:BuildingName">
          <xsl:apply-templates />
        </xsl:for-each>
        <!-- <xsl:for-each select="cbc:BuildingNumber">
               <xsl:text> No:</xsl:text>
               <xsl:apply-templates/>
               <xsl:text>&#160;</xsl:text>
            </xsl:for-each>
            <br/> -->
        <!-- <xsl:for-each select="cbc:Room">
               <xsl:text>Kapı No:</xsl:text>
               <xsl:apply-templates/>
               <xsl:text>&#160;</xsl:text>
            </xsl:for-each>
            <br/> -->
        <xsl:for-each select="cbc:PostalZone">
          <xsl:apply-templates />
          <xsl:text> </xsl:text>
        </xsl:for-each>
        <xsl:if test="cbc:CitySubdivisionName !=''&#xD;&#xA;             			and  cbc:CitySubdivisionName !='-'">
          <xsl:for-each select="cbc:CitySubdivisionName">
            <xsl:apply-templates />
            <xsl:text>/ </xsl:text>
          </xsl:for-each>
        </xsl:if>
        <xsl:if test="cbc:CityName !=''&#xD;&#xA;             			and  cbc:CityName !='-'">
          <xsl:for-each select="cbc:CityName">
            <xsl:apply-templates />
            <xsl:text> </xsl:text>
          </xsl:for-each>
        </xsl:if>
        <xsl:if test="$PartyType='TAXFREE'">
          <br />
          <xsl:value-of select="cac:Country/cbc:Name" />
          <br />
        </xsl:if>
      </xsl:for-each>
    </td>
  </xsl:template>
  <xsl:template name="Party_Other">
    <xsl:param name="PartyType" />
    <xsl:for-each select="cbc:WebsiteURI">
      <tr align="left">
        <td>
          <xsl:text>Web Sitesi: </xsl:text>
          <xsl:value-of select="." />
        </td>
      </tr>
    </xsl:for-each>
    <xsl:for-each select="cac:Contact/cbc:ElectronicMail">
      <tr align="left">
        <td>
          <xsl:text>E-Posta: </xsl:text>
          <xsl:value-of select="." />
        </td>
      </tr>
    </xsl:for-each>
    <xsl:for-each select="cac:Contact">
      <xsl:if test="cbc:Telephone or cbc:Telefax">
        <tr align="left">
          <td style="width:469px; " align="left">
            <xsl:for-each select="cbc:Telephone">
              <xsl:text>Tel: </xsl:text>
              <xsl:apply-templates />
            </xsl:for-each>
            <xsl:for-each select="cbc:Telefax">
              <xsl:text> Fax: </xsl:text>
              <xsl:apply-templates />
            </xsl:for-each>
            <xsl:text> </xsl:text>
          </td>
        </tr>
      </xsl:if>
    </xsl:for-each>
    <xsl:if test="$PartyType!='TAXFREE'">
      <xsl:for-each select="cac:PartyTaxScheme/cac:TaxScheme/cbc:Name">
        <tr align="left">
          <td>
            <xsl:text>Vergi Dairesi: </xsl:text>
            <xsl:apply-templates />
          </td>
        </tr>
      </xsl:for-each>
      <xsl:for-each select="cac:PartyIdentification">
        <tr align="left">
          <td>
            <xsl:value-of select="cbc:ID/@schemeID" />
            <xsl:text>: </xsl:text>
            <xsl:value-of select="cbc:ID" />
          </td>
        </tr>
      </xsl:for-each>
    </xsl:if>
  </xsl:template>
  <xsl:template name="Curr_Type">
    <xsl:value-of select="format-number(., '###.##0,00', 'european')" />
    <xsl:if test="@currencyID">
      <xsl:text>
      </xsl:text>
      <xsl:choose>
        <xsl:when test="@currencyID = 'TRL' or @currencyID = 'TRY'">
          <xsl:text>TL</xsl:text>
        </xsl:when>
        <xsl:otherwise>
          <xsl:value-of select="@currencyID" />
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>
  </xsl:template>
</xsl:stylesheet>
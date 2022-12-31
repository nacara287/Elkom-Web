<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2" xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" xmlns:ccts="urn:un:unece:uncefact:documentation:2" xmlns:clm54217="urn:un:unece:uncefact:codelist:specification:54217:2001" xmlns:clm5639="urn:un:unece:uncefact:codelist:specification:5639:1988" xmlns:clm66411="urn:un:unece:uncefact:codelist:specification:66411:2001" xmlns:clmIANAMIMEMediaType="urn:un:unece:uncefact:codelist:specification:IANAMIMEMediaType:2003" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:link="http://www.xbrl.org/2003/linkbase" xmlns:n1="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2" xmlns:qdt="urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2" xmlns:udt="urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2" xmlns:xbrldi="http://xbrl.org/2006/xbrldi" xmlns:xbrli="http://www.xbrl.org/2003/instance" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:ext="urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2" xmlns:ds="http://www.w3.org/2000/09/xmldsig#" xmlns:xades="http://uri.etsi.org/01903/v1.3.2#" exclude-result-prefixes="cac cbc ccts clm54217 clm5639 clm66411 clmIANAMIMEMediaType fn link n1 qdt udt xbrldi xbrli xdt xlink xs xsd xsi ext ds xades">
	<xsl:decimal-format name="european" decimal-separator="," grouping-separator="." NaN=""/>
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head/>
			<body>
				<p/>
				<table border="0" cellpadding="0" cellspacing="0" style="border-color: blue;" width="800">
					<tbody>
						<tr>
							<td style="width: 205px;">
								<span style="font-size: 10px;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-family: verdana,geneva,sans-serif;">
											<strong>Merkez</strong>
										</span>
									</span>
								</span>
								<table align="left" border="0" cellpadding="0" cellspacing="0" style="font-size: 9px; border-top-color: rgb(0, 0, 0); border-bottom-color: rgb(0, 0, 0); border-top-width: 3px; border-bottom-width: 3px; border-top-style: solid; border-bottom-style: solid;" width="350">
									<tbody>
										<tr align="left">
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:for-each select="//n1:Invoice">
																<xsl:for-each select="cac:AccountingSupplierParty">
																	<xsl:for-each select="cac:Party">
																		<xsl:if test="cac:PartyName">
																			<xsl:value-of select="cac:PartyName/cbc:Name"/>
																			<br/>
																		</xsl:if>
																		<xsl:for-each select="cac:Person">
																			<xsl:for-each select="cbc:Title">
																				<xsl:apply-templates/>
																				<span>
																					<xsl:text> </xsl:text>
																				</span>
																			</xsl:for-each>
																			<xsl:for-each select="cbc:FirstName">
																				<xsl:apply-templates/>
																				<span>
																					<xsl:text> </xsl:text>
																				</span>
																			</xsl:for-each>
																			<xsl:for-each select="cbc:MiddleName">
																				<xsl:apply-templates/>
																				<span>
																					<xsl:text> </xsl:text>
																				</span>
																			</xsl:for-each>
																			<xsl:for-each select="cbc:FamilyName">
																				<xsl:apply-templates/>
																				<span>
																					<xsl:text> </xsl:text>
																				</span>
																			</xsl:for-each>
																			<xsl:for-each select="cbc:NameSuffix">
																				<xsl:apply-templates/>
																			</xsl:for-each>
																		</xsl:for-each>
																	</xsl:for-each>
																</xsl:for-each>
															</xsl:for-each>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr align="left">
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:for-each select="//n1:Invoice">
																<xsl:for-each select="cac:AccountingSupplierParty">
																	<xsl:for-each select="cac:Party">
																		<xsl:for-each select="cac:PostalAddress">
																			<xsl:for-each select="cbc:StreetName">
																				<xsl:apply-templates/>
																				<span>
																					<xsl:text> </xsl:text>
																				</span>
																			</xsl:for-each>
																			<xsl:for-each select="cbc:BuildingName">
																				<xsl:apply-templates/>
																			</xsl:for-each>
																			<xsl:if test="cbc:BuildingNumber">
																				<span>
																					<xsl:text/>
																				</span>
																				<xsl:for-each select="cbc:BuildingNumber">
																					<xsl:apply-templates/>
																				</xsl:for-each>
																				<span>
																					<xsl:text> </xsl:text>
																				</span>
																			</xsl:if>
																			<br/>
																			<xsl:for-each select="cbc:PostalZone">
																				<xsl:apply-templates/>
																				<span>
																					<xsl:text> </xsl:text>
																				</span>
																			</xsl:for-each>
																			<xsl:for-each select="cbc:CitySubdivisionName">
																				<xsl:apply-templates/>
																			</xsl:for-each>
																			<span>
																				<xsl:text/>
																			</span>
																			<xsl:for-each select="cbc:CityName">
																				<xsl:apply-templates/>
																				<span>
																					<xsl:text> </xsl:text>
																				</span>
																			</xsl:for-each>
																		</xsl:for-each>
																	</xsl:for-each>
																</xsl:for-each>
															</xsl:for-each>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr align="left">
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">Tel: <xsl:value-of select="n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:Telephone"/> Faks: <xsl:value-of select="n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:Telefax"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<xsl:if test="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cbc:WebsiteURI != ''">
											<tr>
												<td align="left">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">Web Sitesi: <xsl:value-of select="n1:Invoice/cac:AccountingSupplierParty/cac:Party/cbc:WebsiteURI"/>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<tr align="left">
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">E-posta: <xsl:value-of select="n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:Contact/cbc:ElectronicMail"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">Vergi Dairesi: <xsl:value-of select="n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:for-each select="//n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification">
																<xsl:variable name="schemeID" select="cbc:ID/@schemeID"/>
																<xsl:if test="$schemeID ='TCKN' or $schemeID ='VKN'">
																	<xsl:value-of select="$schemeID"/> : <xsl:value-of select="cbc:ID"/>
																</xsl:if>
															</xsl:for-each>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">Mersis No: <xsl:value-of select="n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID = 'MERSISNO']"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">Ticaret Sicil No: <xsl:value-of select="n1:Invoice/cac:AccountingSupplierParty/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID = 'TICARETSICILNO']"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
									</tbody>
								</table>
							</td>
							<td style="width: 197px; text-align: center;">
								<span style="font-size: 10px;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-family: verdana,geneva,sans-serif;">
											<img align="middle" alt="GIB Logo" src="data:image/jpeg;base64,/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAABkAAD/4QMZaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjYtYzEzMiA3OS4xNTkyODQsIDIwMTYvMDQvMTktMTM6MTM6NDAgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjZDNDJBNEI2QjVCRDExRThCQjM0REIwQkZGMEQxODY0IiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjZDNDJBNEI1QjVCRDExRThCQjM0REIwQkZGMEQxODY0IiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDUzQgV2luZG93cyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSIzREVENkU1N0FDREVDNEJBNzkxNUM2M0NCN0RENzM0NyIgc3RSZWY6ZG9jdW1lbnRJRD0iM0RFRDZFNTdBQ0RFQzRCQTc5MTVDNjNDQjdERDczNDciLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz7/7gAOQWRvYmUAZMAAAAAB/9sAhAABAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEB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" style="width: 70px;"/>
											<br/>
											<br/>
											<font align="center">e-Arşiv Fatura<img alt="" src="data:image/jpg;base64,iVBORw0KGgoAAAANSUhEUgAAAcwAAADYCAYAAABm69O/AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAFiUAABYlAUlSJPAAAP+lSURBVHhe7L0HeFbVtjXM6dVjP3ZFBKUpCNIUpUhRBBQRGyigiFTpSO+99xp6ILQECCQkEAIhBJIASSjpvZCEFNJ7wvjHWDsvoEfP5X7/vc/3P+d/Z5js/e69+pprjjnXXnvtGrCTnexkJzvZyU7/JdkB0052spOd7GSn+yA7YNrJTnayk53sdB9kB0w72clOdrKTne6D7IBpJzvZyU52stN9kB0w7WQnO9nJTna6D7IDpp3sZCc72clO90F2wLSTnexkJzvZ6T7IDph2spOd7GQnO90H2QHTTnayk53sZKf7IDtg2slOdrKTnex0H2QHTDvZyU52spOd7oPsgGknO9nJTnay032QHTDtZCc72clOdroPsgOmnexkJzvZyU73QXbAtJOd7GQnO9npPsgOmHayk53sZCc73QfZAdNOdrKTnexkp/sgO2DayU52spOd7HQfZAdMO9nJTnayk53ug+yAaSc72clOdrLTfZAdMO1kJzvZyU52ug+yA6ad7GQnO9nJTvdBdsC0k53sZCc72ek+yA6YdrKTnexkJzvdB9kB0052spOd7GSn+yA7YNrJTnayk53sdB9kB0w72clOdrKTne6D7IBpJzvZyU52stN9kB0w7WQnO9nJTna6D7IDpp3sZCc72clO90F2wLSTnexkJzvZ6T7IDph2spOd7GQnO90H2QHTTnayk53sZKf7IDtg2slOdrKTnex0H2QHTDvZyU52spOd7oPsgGknO9nJTnay032QHTDtZCc72clOdroPsgOmnexkJzvZyU73QXbAtJOd7GQnO9npPsgOmHb6v0i37+H/efrfTd1O/+f03+2Ze8Pfy79G9xPmf55u375Nrqo+6reNf60cum5jO/2/p//99rQDpp3+L9L/roAr1arqo53+v0TqFVvP3E/v2MLZ4v1XvWoLez9p/88QIRJVBEuLeV59XfRroKk4Cqn/7fT/ltSGP+f/ebID5n8s/ZIA2fjf0S+FF/8a/ffC/DT0zxXgL/F/TVbIn8e7jUpyRfXx1+jeGPdD94a3FJ7191O6N9T/Lfr1Mtx751/v/pTuN9z9k1KqvIfvpwSS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" style="width: 140px; height: 68px;"/>
											</font>
										</span>
									</span>
								</span>
							</td>
							<td style="width: 245px; text-align: center;">
								<img alt="" src="data:image/jpeg;base64,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" style="width: 200px; height: 162px;"/>
							</td>
						</tr>
						<tr>
							<td style="width: 205px;"> </td>
							<td style="width: 197px;"> </td>
							<td style="width: 245px;"> </td>
						</tr>
						<tr>
							<td style="width: 205px;">
								<table align="left" border="0" cellpadding="0" cellspacing="0" id="customerPartyTable" style="border-top-color: rgb(0, 0, 0); border-bottom-color: rgb(0, 0, 0); border-top-width: 3px; border-bottom-width: 3px; border-top-style: solid; border-bottom-style: solid;" width="350">
									<tbody>
										<tr>
											<td align="left" style="width: 469px;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<strong>SAYIN</strong>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left" style="width: 469px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:for-each select="//n1:Invoice">
																		<xsl:for-each select="cac:AccountingCustomerParty">
																			<xsl:for-each select="cac:Party">
																				<xsl:if test="cac:PartyName">
																					<xsl:value-of select="cac:PartyName/cbc:Name"/>
																					<br/>
																				</xsl:if>
																				<xsl:for-each select="cac:Person">
																					<xsl:for-each select="cbc:Title">
																						<xsl:apply-templates/>
																						<span>
																							<xsl:text> </xsl:text>
																						</span>
																					</xsl:for-each>
																					<xsl:for-each select="cbc:FirstName">
																						<xsl:apply-templates/>
																						<span>
																							<xsl:text> </xsl:text>
																						</span>
																					</xsl:for-each>
																					<xsl:for-each select="cbc:MiddleName">
																						<xsl:apply-templates/>
																						<span>
																							<xsl:text> </xsl:text>
																						</span>
																					</xsl:for-each>
																					<xsl:for-each select="cbc:FamilyName">
																						<xsl:apply-templates/>
																						<span>
																							<xsl:text> </xsl:text>
																						</span>
																					</xsl:for-each>
																					<xsl:for-each select="cbc:NameSuffix">
																						<xsl:apply-templates/>
																					</xsl:for-each>
																				</xsl:for-each>
																			</xsl:for-each>
																		</xsl:for-each>
																	</xsl:for-each>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:for-each select="//n1:Invoice">
																		<xsl:for-each select="cac:BuyerCustomerParty">
																			<xsl:for-each select="cac:Party">
																				<xsl:if test="cac:PartyName">
																					<xsl:value-of select="cac:PartyName/cbc:Name"/>
																					<br/>
																				</xsl:if>
																				<xsl:for-each select="cac:Person">
																					<xsl:for-each select="cbc:Title">
																						<xsl:apply-templates/>
																						<span>
																							<xsl:text> </xsl:text>
																						</span>
																					</xsl:for-each>
																					<xsl:for-each select="cbc:FirstName">
																						<xsl:apply-templates/>
																						<span>
																							<xsl:text> </xsl:text>
																						</span>
																					</xsl:for-each>
																					<xsl:for-each select="cbc:MiddleName">
																						<xsl:apply-templates/>
																						<span>
																							<xsl:text> </xsl:text>
																						</span>
																					</xsl:for-each>
																					<xsl:for-each select="cbc:FamilyName">
																						<xsl:apply-templates/>
																						<span>
																							<xsl:text> </xsl:text>
																						</span>
																					</xsl:for-each>
																					<xsl:for-each select="cbc:NameSuffix">
																						<xsl:apply-templates/>
																					</xsl:for-each>
																				</xsl:for-each>
																			</xsl:for-each>
																		</xsl:for-each>
																	</xsl:for-each>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr align="left">
											<td align="left" style="width: 469px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:StreetName"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:StreetName"/>
																</xsl:otherwise>
															</xsl:choose>
															<br/>
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:BuildingName"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:BuildingName"/>
																</xsl:otherwise>
															</xsl:choose>
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:BuildingNumber"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:BuildingNumber"/>
																</xsl:otherwise>
															</xsl:choose>
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:Room"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:PostalAddress/cac:Party/cac:PostalAddress/cbc:Room"/>
																</xsl:otherwise>
															</xsl:choose>
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:Region"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:Region"/>
																</xsl:otherwise>
															</xsl:choose>
															<br/>
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:PostalZone"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:PostalZone"/>
																</xsl:otherwise>
															</xsl:choose>
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:CitySubdivisionName"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CitySubdivisionName"/>
																</xsl:otherwise>
															</xsl:choose>
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:CityName"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CityName"/>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left" style="width: 469px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:if test="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:ElectronicMail !=''">
																		<xsl:text>E-Posta: </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:ElectronicMail"/>
																	</xsl:if>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:if test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:ElectronicMail != ''">
																		<xsl:text>E-Posta: </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:ElectronicMail"/>
																	</xsl:if>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left" style="width: 469px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:if test="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telephone !=''">
																		<xsl:text>Tel: </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telephone"/>
																	</xsl:if>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:if test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telephone != ''">
																		<xsl:text>Tel: </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telephone"/>
																	</xsl:if>
																</xsl:otherwise>
															</xsl:choose>
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:if test="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telefax !=''">
																		<xsl:text>Faks: </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telefax"/>
																	</xsl:if>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:if test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telefax != ''">
																		<xsl:text>Faks: </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telefax"/>
																	</xsl:if>
																</xsl:otherwise>
															</xsl:choose>
														</span>
													</span>
												</span>
											</td>
                      <td align="left" style="width: 469px;">
                        <span style="color: rgb(105, 105, 105);">
                          <span style="font-size: 10px;">
                            <span style="font-family: verdana,geneva,sans-serif;">
                              <xsl:choose>
                                <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                                  <xsl:if test="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telephone !=''">
                                    <xsl:text>Tel: </xsl:text>
                                    <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telephone"/>
                                  </xsl:if>
                                </xsl:when>
                                <xsl:otherwise>
                                  <xsl:if test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telephone != ''">
                                    <xsl:text>Tel: </xsl:text>
                                    <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telephone"/>
                                  </xsl:if>
                                </xsl:otherwise>
                              </xsl:choose>
                              <xsl:choose>
                                <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                                  <xsl:if test="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telefax !=''">
                                    <xsl:text>Faks: </xsl:text>
                                    <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telefax"/>
                                  </xsl:if>
                                </xsl:when>
                                <xsl:otherwise>
                                  <xsl:if test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telefax != ''">
                                    <xsl:text>Faks: </xsl:text>
                                    <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telefax"/>
                                  </xsl:if>
                                </xsl:otherwise>
                              </xsl:choose>
                            </span>
                          </span>
                        </span>
                      </td>
										</tr>
										<tr>
											<td align="left" style="width: 469px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:if test="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name !=''">
																		<xsl:text>Vergi Dairesi: </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyTaxScheme/cac:TaxScheme/cbc:Name"/>
																	</xsl:if>
																</xsl:when>
															</xsl:choose>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left" style="width: 469px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:for-each select="//n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyIdentification">
																		<xsl:variable name="schemeID" select="cbc:ID/@schemeID"/>
																		<xsl:if test="$schemeID ='TCKN' or $schemeID ='VKN'">
																			<xsl:value-of select="$schemeID"/> : <xsl:value-of select="cbc:ID"/>
																		</xsl:if>
																	</xsl:for-each>
																</xsl:when>
															</xsl:choose>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">Ticaret Sicil No: <xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID = 'MERSISNO']"/>
																</xsl:when>
															</xsl:choose>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td align="left">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">Mersis No: <xsl:choose>
																<xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PartyIdentification/cbc:ID[@schemeID = 'TICARETSICILNO']"/>
																</xsl:when>
															</xsl:choose>
														</span>
													</span>
												</span>
											</td>
										</tr>
									</tbody>
								</table>
							</td>
							<td style="width: 197px;"> </td>
							<td style="width: 245px;">
								<table style="width: 242px; border-collapse: collapse;">
									<tbody>
										<tr>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 116px;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Fatura Tipi:</span>
														</span>
													</span>
												</span>
											</td>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 120px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:value-of select="n1:Invoice/cbc:InvoiceTypeCode"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 116px;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Belge </span>
															<span style="font-weight: bold;">No:</span>
														</span>
													</span>
												</span>
											</td>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 120px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:value-of select="n1:Invoice/cbc:ID"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 116px;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Fatura Tarihi:</span>
														</span>
													</span>
												</span>
											</td>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 120px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:for-each select="//n1:Invoice">
																<xsl:for-each select="cbc:IssueDate">
																	<xsl:value-of select="substring(.,9,2)"/>-<xsl:value-of select="substring(.,6,2)"/>-<xsl:value-of select="substring(.,1,4)"/>
																</xsl:for-each>
															</xsl:for-each>
															<xsl:value-of select="n1:Invoice/cbc:IssueTime"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<xsl:if test="//n1:Invoice/cac:DespatchDocumentReference">
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 116px;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<strong>İrsaliye No:</strong>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:DespatchDocumentReference">
																	<xsl:value-of select="cbc:ID"/>
																	<br/>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<xsl:if test="//n1:Invoice/cac:DespatchDocumentReference">
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 116px;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<strong>İrsaliye Tarihi:</strong>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:DespatchDocumentReference">
																	<xsl:variable name="ddt" select="cbc:IssueDate"/>
																	<xsl:value-of select="concat(substring($ddt, 9, 2), '-', substring($ddt, 6, 2), '-', substring($ddt, 1, 4))"/>
																	<br/>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<xsl:if test="//n1:Invoice/cac:OrderReference">
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 116px;">
													<strong style="color: rgb(105, 105, 105); font-family: verdana, geneva, sans-serif; font-size: 10px;">Sipariş No:</strong>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:value-of select="n1:Invoice/cac:OrderReference/cbc:ID"/>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<xsl:if test="//n1:Invoice/cac:OrderReference">
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 116px;">
													<strong style="color: rgb(105, 105, 105); font-family: verdana, geneva, sans-serif; font-size: 10px;">Sipariş Tarihi:</strong>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:variable name="spdt" select="n1:Invoice/cac:OrderReference/cbc:IssueDate"/>
																<xsl:value-of select="concat(substring($spdt, 9, 2), '-', substring($spdt, 6, 2), '-', substring($spdt, 1, 4))"/>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
											<xsl:if test="cbc:ID = 'faturaIptal' and cbc:DocumentType = '1'">
												<tr>
													<td align="left" id="lineTableTd" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 116px;">
														<strong style="color: rgb(105, 105, 105); font-family: verdana, geneva, sans-serif; font-size: 10px;">İptal Tarihi:</strong>
													</td>
													<td id="lineTableTd" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 120px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-size: 10px;">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<xsl:for-each select="cbc:IssueDate">
																		<xsl:value-of select="substring(.,9,2)"/>-<xsl:value-of select="substring(.,6,2)"/>-<xsl:value-of select="substring(.,1,4)"/>
																	</xsl:for-each>
																</span>
																<span style="font-size: 150pt;opacity: 0.5;color: red;position: absolute;top: 350px;left: 220px;">İptal</span>
															</span>
														</span>
													</td>
												</tr>
											</xsl:if>
										</xsl:for-each>
									</tbody>
								</table>
							</td>
						</tr>
						<td align="center">
							<div>
								<xsl:for-each select="//n1:Invoice">
									<xsl:for-each select="cac:AdditionalDocumentReference">
										<xsl:if test="cbc:DocumentType = 'CARGO_BARCODE' or cbc:DocumentType = 'CARGO_BARCODE'">
											<xsl:for-each select="cac:Attachment">
												<img style="width:190px;" align="center" alt="QrCode">
													<xsl:attribute name="src">data:image/jpeg;base64,<xsl:value-of select="cbc:EmbeddedDocumentBinaryObject"/>
													</xsl:attribute>
												</img>
											</xsl:for-each>
										</xsl:if>
									</xsl:for-each>
								</xsl:for-each>
							</div>
						</td>
						<tr>
							<td style="width: 205px;">
								<span style="font-family: verdana,geneva,sans-serif;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<strong>ETTN: </strong>
											<xsl:value-of select="n1:Invoice/cbc:UUID"/>
										</span>
									</span>
								</span>
							</td>
							<td style="width: 197px;"> </td>
							<td style="width: 245px;"> </td>
						</tr>
					</tbody>
				</table>
			</body>
		</html>
		<html>
			<head/>
			<body>
				<table style="border: 2px solid rgb(0, 0, 0); border-image: none; width: 800px; border-collapse: collapse; margin-top: 20px;">
					<tbody>
						<tr>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 3%;text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Sıra No</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 20%;text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Malzeme / Hizmet</span>
										</span>
									</strong>
								</span>
							</td>
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:SellersItemIdentification/cbc:ID">
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10%;text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Malzeme / Hizmet Kodu</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cbc:Note">
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10%;text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Malzeme / Hizmet Açıklaması</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cbc:Description">
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 7%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Açıklamalar</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:ManufacturersItemIdentification/cbc:ID">
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Barkod</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 6%; text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Miktar</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 8%; text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Birim Fiyat</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 7%;text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">İskonto Oranı</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 11%;text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">İskonto Tutarı</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 8%; text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">KDV Oranı</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 8%; text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">KDV Tutarı</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 4%;text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Diğer Vergiler</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Malzeme / Hizmet Tutarı</span>
										</span>
									</strong>
								</span>
							</td>
						</tr>
						<xsl:for-each select="//n1:Invoice/cac:InvoiceLine">
							<tr>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 3%; text-align: left;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:value-of select="./cbc:ID"/>
											</span>
										</span>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10%; text-align: left;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:value-of select="./cac:Item/cbc:Name"/>
											</span>
										</span>
									</span>
								</td>
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:SellersItemIdentification/cbc:ID">
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10%; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:choose>
														<xsl:when test="./cac:Item/cac:SellersItemIdentification/cbc:ID != ''">
															<xsl:value-of select="./cac:Item/cac:SellersItemIdentification/cbc:ID"/>
														</xsl:when>
													</xsl:choose>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cbc:Description">
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 6%; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Item/cbc:Description"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cbc:Note">
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 7%; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:for-each select="./cbc:Note">
														<span>
															<xsl:text> </xsl:text>
															<xsl:value-of select="."/>
														</span>
														<br/>
													</xsl:for-each>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:ManufacturersItemIdentification/cbc:ID">
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 6%; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Item/cac:ManufacturersItemIdentification/cbc:ID"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 6%; text-align: right;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:value-of select="format-number(./cbc:InvoicedQuantity, '###.##0,####', 'european')"/>
												<xsl:if test="./cbc:InvoicedQuantity/@unitCode">
													<xsl:for-each select="./cbc:InvoicedQuantity">
														<xsl:text/>
														<xsl:choose>
															<xsl:when test="@unitCode  = 'SA'">
																<span>
																	<xsl:text>ÇUVAL</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = '26'">
																<span>
																	<xsl:text>Ton</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'BX'">
																<span>
																	<xsl:text>Kutu</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'SET'">
																<span>
																	<xsl:text>Takım</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'LTR'">
																<span>
																	<xsl:text>LT</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'EA'">
																<span>
																	<xsl:text>Adet</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'NIU'">
																<span>
																	<xsl:text>Adet</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'C62'">
																<span>
																	<xsl:text>Adet</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KGM'">
																<span>
																	<xsl:text>KG</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KJO'">
																<span>
																	<xsl:text>kJ</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'GRM'">
																<span>
																	<xsl:text>GR</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MGM'">
																<span>
																	<xsl:text>MG</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'NT'">
																<span>
																	<xsl:text>Net Ton</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'GT'">
																<span>
																	<xsl:text>Gross Ton</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MTR'">
																<span>
																	<xsl:text>M</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MMT'">
																<span>
																	<xsl:text>MM</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KTM'">
																<span>
																	<xsl:text>KM</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MLT'">
																<span>
																	<xsl:text>ML</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MMQ'">
																<span>
																	<xsl:text>MM³</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CLT'">
																<span>
																	<xsl:text>CL</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CMK'">
																<span>
																	<xsl:text>CM²</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CMQ'">
																<span>
																	<xsl:text>CM³</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CMT'">
																<span>
																	<xsl:text>CM</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MTK'">
																<span>
																	<xsl:text>M²</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MTQ'">
																<span>
																	<xsl:text>M³</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'DAY'">
																<span>
																	<xsl:text>Gün</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MON'">
																<span>
																	<xsl:text>Ay</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'PK'">
																<span>
																	<xsl:text>Paket</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'SL'">
																<span>
																	<xsl:text>Palet</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = '2W'">
																<span>
																	<xsl:text>Bidon</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KWH'">
																<span>
																	<xsl:text>KWH</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'INH'">
																<span>
																	<xsl:text>IN</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'FOT'">
																<span>
																	<xsl:text>FT</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MMK'">
																<span>
																	<xsl:text>MM²</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'INK'">
																<span>
																	<xsl:text>IN²</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'FTK'">
																<span>
																	<xsl:text>FT²</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'INQ'">
																<span>
																	<xsl:text>IN³</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'FTQ'">
																<span>
																	<xsl:text>FT³</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'ONZ'">
																<span>
																	<xsl:text>OZ</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'LBR'">
																<span>
																	<xsl:text>LB</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'PR'">
																<span>
																	<xsl:text>Çift</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'BE'">
																<span>
																	<xsl:text>Deste</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'NPL'">
																<span>
																	<xsl:text>Koli</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'SW'">
																<span>
																	<xsl:text>Top</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'QB'">
																<span>
																	<xsl:text>Cilt</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'SEC'">
																<span>
																	<xsl:text>Saniye</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = '5C'">
																<span>
																	<xsl:text>Teneke</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'MIN'">
																<span>
																	<xsl:text>Dakika</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'DZN'">
																<span>
																	<xsl:text>Düzine</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'DPC'">
																<span>
																	<xsl:text>Düzine</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = '5B'">
																<span>
																	<xsl:text>Takım</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'DMQ'">
																<span>
																	<xsl:text>Desimetreküp</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'WEE'">
																<span>
																	<xsl:text>Hafta</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'HUR'">
																<span>
																	<xsl:text>Saat</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'ANN'">
																<span>
																	<xsl:text>Yıl</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'RO'">
																<span>
																	<xsl:text>Rulo</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CTM'">
																<span>
																	<xsl:text>Karat</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'PTN'">
																<span>
																	<xsl:text>Parça,Kısım</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'B4'">
																<span>
																	<xsl:text>Varil</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = '28'">
																<span>
																	<xsl:text>KG</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'BG'">
																<span>
																	<xsl:text>Çuval</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'BJ'">
																<span>
																	<xsl:text>Kova</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'BK'">
																<span>
																	<xsl:text>Sepet</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'BL'">
																<span>
																	<xsl:text>Balya</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'BO'">
																<span>
																	<xsl:text>Şişe</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CO'">
																<span>
																	<xsl:text>Damacana</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CQ'">
																<span>
																	<xsl:text>Kartuş</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CS'">
																<span>
																	<xsl:text>Kasa</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CT'">
																<span>
																	<xsl:text>Karton</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = '11'">
																<span>
																	<xsl:text>Takım</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = '2W'">
																<span>
																	<xsl:text>Sepet</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'B32'">
																<span>
																	<xsl:text>KG-METRE KARE</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'CCT'">
																<span>
																	<xsl:text>TON BAŞINA TAŞIMA KAPASİTESİ</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'D30'">
																<span>
																	<xsl:text>BRÜT KALORİ DEĞERİ</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'D40'">
																<span>
																	<xsl:text>BİN LİTRE</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'GFI'">
																<span>
																	<xsl:text>FISSILE İZOTOP GRAMI</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'H62'">
																<span>
																	<xsl:text>YÜZ ADET</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'K20'">
																<span>
																	<xsl:text>KİLOGRAM POTASYUM OKSİT</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'K58'">
																<span>
																	<xsl:text>KURUTULMUŞ NET AĞIRLIKLI KİLOGRAMI</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'K62'">
																<span>
																	<xsl:text>KİLOGRAM-ADET</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KMA'">
																<span>
																	<xsl:text>METİL AMİNLERİN KİLOGRAMI</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KNI'">
																<span>
																	<xsl:text>AZOTUN KİLOGRAMI</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KPH'">
																<span>
																	<xsl:text>Kg POTASYUM OKSİD</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KSD'">
																<span>
																	<xsl:text>%90 KURU ÜRÜN KİLOGRAMI</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KSH'">
																<span>
																	<xsl:text>SODYUM HİDROKSİT KİLOGRAMI</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KUR'">
																<span>
																	<xsl:text>URANYUM KİLOGRAMI</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KWT'">
																<span>
																	<xsl:text>KİLOWATT</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'KWT'">
																<span>
																	<xsl:text>KİLOWATT</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'LPA'">
																<span>
																	<xsl:text>SAF ALKOL LİTRESİ</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'NCL'">
																<span>
																	<xsl:text>HÜCRE ADEDİ</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'R9'">
																<span>
																	<xsl:text>BİN METRE KÜP</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'SET'">
																<span>
																	<xsl:text>SET</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'T3'">
																<span>
																	<xsl:text>BİN ADET</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'D61'">
																<span>
																	<xsl:text>Dakika</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test="@unitCode  = 'D62'">
																<span>
																	<xsl:text>Saniye</xsl:text>
																</span>
															</xsl:when>
															<xsl:otherwise>
																<span>
																	<xsl:value-of select="@unitCode"/>
																</span>
															</xsl:otherwise>
														</xsl:choose>
													</xsl:for-each>
												</xsl:if>
											</span>
										</span>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 13%; text-align: right;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:value-of select="format-number(./cac:Price/cbc:PriceAmount, '###.##0,0000', 'european')"/>
												<xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID">
													<xsl:text/>
													<xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID = 'TRY' ">
														<xsl:text>TL</xsl:text>
													</xsl:if>
													<xsl:if test="./cac:Price/cbc:PriceAmount/@currencyID != 'TRY'">
														<xsl:value-of select="./cac:Price/cbc:PriceAmount/@currencyID"/>
													</xsl:if>
												</xsl:if>
											</span>
										</span>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 7%; text-align: right;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:for-each select="./cac:AllowanceCharge">
													<xsl:text/>
													<table id="allowanceChargeRateTable" border="0" cellpadding="0" cellspacing="0" align="right" tagid="allowanceChargeRate" style="clear:both" width="100%">
														<tbody>
															<tr id="budgetContainerTr" align="right">
																<td align="right">
																	<xsl:text>% </xsl:text>
																	<xsl:value-of select="format-number(cbc:MultiplierFactorNumeric*100, '###.##0,00', 'european')"/>
																</td>
															</tr>
														</tbody>
													</table>
												</xsl:for-each>
											</span>
										</span>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 11%; text-align: right;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:for-each select="./cac:AllowanceCharge">
													<xsl:text/>
													<table id="allowanceChargeAmountTable" border="0" cellpadding="0" cellspacing="0" align="right" tagid="allowanceChargeAmount" style="clear:both" width="100%">
														<tbody>
															<tr id="budgetContainerTr" align="right">
																<td align="right">
																	<xsl:value-of select="format-number(cbc:Amount, '###.##0,00', 'european')"/>
																	<xsl:if test="cbc:Amount/@currencyID">
																		<xsl:text/>
																		<xsl:if test="cbc:Amount/@currencyID = 'TRY'">
																			<xsl:text>TL </xsl:text>
																		</xsl:if>
																		<xsl:if test="cbc:Amount/@currencyID != 'TRY'">
																			<xsl:value-of select="cbc:Amount/@currencyID"/>
																		</xsl:if>
																	</xsl:if>
																</td>
															</tr>
														</tbody>
													</table>
												</xsl:for-each>
											</span>
										</span>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 8%; text-align: right;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:for-each select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
													<xsl:if test="cbc:TaxTypeCode='0015' ">
														<xsl:if test="../../cbc:Percent">
															<xsl:text>%</xsl:text>
															<xsl:value-of select="format-number(../../cbc:Percent, '###.##0,00', 'european')"/>
														</xsl:if>
													</xsl:if>
												</xsl:for-each>
											</span>
										</span>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 8%; text-align: right;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:for-each select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
													<xsl:if test="cbc:TaxTypeCode='0015' ">
														<xsl:text/>
														<xsl:value-of select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
														<xsl:if test="../../cbc:TaxAmount/@currencyID">
															<xsl:text/>
															<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRY'">
																<xsl:text>TL</xsl:text>
															</xsl:if>
															<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRY'">
																<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
															</xsl:if>
														</xsl:if>
													</xsl:if>
												</xsl:for-each>
											</span>
										</span>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 4%; text-align: right;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:for-each select="./cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cac:TaxScheme">
													<xsl:if test="cbc:TaxTypeCode!='0015' ">
														<xsl:text/>
														<xsl:value-of select="cbc:Name"/>
														<xsl:if test="../../cbc:Percent">
															<xsl:text>(%</xsl:text>
															<xsl:value-of select="format-number(../../cbc:Percent, '###.##0,00', 'european')"/>
															<xsl:text>)=</xsl:text>
														</xsl:if>
														<xsl:value-of select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
														<xsl:if test="../../cbc:TaxAmount/@currencyID">
															<xsl:text/>
															<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRY'">
																<xsl:text>TL</xsl:text>
															</xsl:if>
															<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRY'">
																<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
															</xsl:if>
														</xsl:if>
													</xsl:if>
												</xsl:for-each>
												<xsl:for-each select="./cac:WithholdingTaxTotal/cac:TaxSubtotal">
													<xsl:if test="not(cbc:TaxAmount = 0)">
														<xsl:choose>
															<xsl:when test="cac:TaxCategory/cac:TaxScheme/cbc:Name=''">
																<xsl:text>Diğer Vergiler Toplamı </xsl:text>
															</xsl:when>
															<xsl:otherwise>
																<xsl:text>Tevkifat (</xsl:text>
																<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode"/>
																<xsl:text>-</xsl:text>
																<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name"/>
																<xsl:text>)</xsl:text>
															</xsl:otherwise>
														</xsl:choose>
														<xsl:if test="cbc:Percent !=''">
															<xsl:text>(%</xsl:text>
															<xsl:value-of select=" format-number(cbc:Percent, '###.##0,00', 'european')"/>
															<xsl:text>)= </xsl:text>
														</xsl:if>
														<xsl:value-of select="format-number(../cbc:TaxAmount, '###.##0,00', 'european')"/>
														<xsl:if test="../cbc:TaxAmount/@currencyID">
															<xsl:if test="../cbc:TaxAmount/@currencyID = 'TRY'">
																<xsl:text>TL</xsl:text>
															</xsl:if>
															<xsl:if test="../cbc:TaxAmount/@currencyID != 'TRY'">
																<xsl:value-of select="../cbc:TaxAmount/@currencyID"/>
															</xsl:if>
														</xsl:if>
													</xsl:if>
												</xsl:for-each>
											</span>
										</span>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-size: 10px;">
											<span style="font-family: verdana,geneva,sans-serif;">
												<xsl:value-of select="format-number(./cbc:LineExtensionAmount, '###.##0,00', 'european')"/>
												<xsl:if test="./cbc:LineExtensionAmount/@currencyID">
													<xsl:text/>
													<xsl:if test="./cbc:LineExtensionAmount/@currencyID = 'TRY' ">
														<xsl:text>TL</xsl:text>
													</xsl:if>
													<xsl:if test="./cbc:LineExtensionAmount/@currencyID != 'TRY' ">
														<xsl:value-of select="./cbc:LineExtensionAmount/@currencyID"/>
													</xsl:if>
												</xsl:if>
											</span>
										</span>
									</span>
								</td>
							</tr>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
		<html>
			<head/>
			<body>
				<table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
					<tbody>
						<tr>
							<td align="right">
								<table border="1" bordercolor="#a4a4a4" cellpadding="0" cellspacing="0" id="budgetContainerTable" style="width: 371px;" width="500">
									<tbody>
										<tr align="right" id="budgetContainerTr">
											<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Mal / Hizmet Toplam Tutarı</span>
														</span>
													</span>
												</span>
											</td>
											<td align="right" id="lineTableBudgetTd" style="width: 120px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:value-of select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount, '###.##0,00', 'european')"/>
															<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID">
																<xsl:text/>
																<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID = 'TRY'">
																	<xsl:text>TL</xsl:text>
																</xsl:if>
																<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRY'">
																	<xsl:value-of select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID"/>
																</xsl:if>
															</xsl:if>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<xsl:if test="not(//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount = 0)">
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<strong>
														<span style="color: rgb(105, 105, 105);">
															<span style="font-size: 10px;">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<xsl:text>Toplam İskonto</xsl:text>
																	<xsl:if test="//n1:Invoice/cac:AllowanceCharge/cbc:MultiplierFactorNumeric">
																		<xsl:text>(%</xsl:text>
																		<xsl:value-of select="format-number((//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount*100) div //n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount, '###.##0,00', 'european')"/>
																		<xsl:text>)</xsl:text>
																	</xsl:if>
																</span>
															</span>
														</span>
													</strong>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:value-of select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount, '###.##0,00', 'european')"/>
																<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID">
																	<xsl:text/>
																	<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID = 'TRY'">
																		<xsl:text>TL</xsl:text>
																	</xsl:if>
																	<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID != 'TRY'">
																		<xsl:value-of select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:AllowanceTotalAmount/@currencyID"/>
																	</xsl:if>
																</xsl:if>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<xsl:if test="not(//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount = 0)">
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<strong>
														<span style="color: rgb(105, 105, 105);">
															<span style="font-size: 10px;">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<span style="font-weight: bold;">Toplam Masraf</span>
																</span>
															</span>
														</span>
													</strong>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:value-of select="format-number(//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount, '###.##0,00', 'european')"/>
																<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount/@currencyID">
																	<xsl:text/>
																	<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount/@currencyID = 'TRY'">
																		<xsl:text>TL</xsl:text>
																	</xsl:if>
																	<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount/@currencyID != 'TRY'">
																		<xsl:text> </xsl:text>
																		<xsl:value-of select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:ChargeTotalAmount/@currencyID"/>
																	</xsl:if>
																</xsl:if>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<tr align="right" id="budgetContainerTr">
											<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
												<strong>
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
																	<table id="taxSubtotalHeaderTable" cellpadding="0" cellspacing="0" width="100%" tagid="taxtable">
																		<tbody>
																			<tr align="right" style="width: 319px;">
																				<td width="100%" align="right">
																					<span style="font-weight:bold; ">
																						<xsl:choose>
																							<xsl:when test="cac:TaxCategory/cac:TaxScheme/cbc:Name=''">
																								<xsl:text>Diğer Vergiler Toplamı </xsl:text>
																							</xsl:when>
																							<xsl:otherwise>
																								<xsl:text>Hesaplanan </xsl:text>
																								<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name"/>
																							</xsl:otherwise>
																						</xsl:choose>
																						<xsl:text>(% </xsl:text>
																						<xsl:value-of select=" format-number(cbc:Percent, '###.##0,00', 'european')"/>
																						<xsl:text>) </xsl:text>
																					</span>
																				</td>
																			</tr>
																		</tbody>
																	</table>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</strong>
											</td>
											<td align="right" id="lineTableBudgetTd" style="width: 120px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
																<table id="taxSubtotalsTable" cellpadding="0" cellspacing="0" align="right" tagid="taxtable" style="clear:both" width="100%">
																	<tbody>
																		<tr id="budgetContainerTr" align="right">
																			<td align="right">
																				<xsl:for-each select="cac:TaxCategory/cac:TaxScheme">
																					<xsl:value-of select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
																					<xsl:if test="../../cbc:TaxAmount/@currencyID">
																						<xsl:text/>
																						<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRY'">
																							<xsl:text>TL </xsl:text>
																						</xsl:if>
																						<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRY'">
																							<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
																						</xsl:if>
																					</xsl:if>
																				</xsl:for-each>
																			</td>
																		</tr>
																	</tbody>
																</table>
															</xsl:for-each>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<xsl:if test="//n1:Invoice/cac:WithholdingTaxTotal">
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<strong>
														<span style="color: rgb(105, 105, 105);">
															<span style="font-size: 10px;">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<xsl:for-each select="//n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal">
																		<xsl:if test="not(cbc:Percent = 0.0000) or not(cbc:TaxAmount = 0)">
																			<table id="taxSubtotalHeaderTable" cellpadding="0" cellspacing="0" width="100%">
																				<tbody>
																					<tr align="right" style="width: 319px;" height="80">
																						<td width="100%" align="right" style="border-bottom: 1px solid #a4a4a4;">
																							<span style="font-weight:bold; ">
																								<xsl:choose>
																									<xsl:when test="cac:TaxCategory/cac:TaxScheme/cbc:Name=''">
																										<xsl:text>Diğer Vergiler Toplamı </xsl:text>
																									</xsl:when>
																									<xsl:otherwise>
																										<xsl:text>Tevkifat </xsl:text>
																										<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name"/>
																									</xsl:otherwise>
																								</xsl:choose>
																								<xsl:text>(%</xsl:text>
																								<xsl:value-of select=" format-number(cbc:Percent, '###.##0,00', 'european')"/>
																								<xsl:text>)</xsl:text>
																							</span>
																						</td>
																					</tr>
																				</tbody>
																			</table>
																		</xsl:if>
																	</xsl:for-each>
																</span>
															</span>
														</span>
													</strong>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal">
																	<xsl:if test="not(cbc:Percent = 0.0000) or not(cbc:TaxAmount = 0)">
																		<table id="taxSubtotalsTable" cellpadding="0" cellspacing="0" align="right" style="clear:both" width="100%">
																			<tbody>
																				<tr id="budgetContainerTr" align="right" height="80">
																					<td align="right" style="border-bottom: 1px solid #a4a4a4;">
																						<xsl:for-each select="cac:TaxCategory/cac:TaxScheme">
																							<xsl:value-of select="format-number(../../cbc:TaxAmount, '###.##0,00', 'european')"/>
																							<xsl:if test="../../cbc:TaxAmount/@currencyID">
																								<xsl:text/>
																								<xsl:if test="../../cbc:TaxAmount/@currencyID = 'TRY'">
																									<xsl:text>TL</xsl:text>
																								</xsl:if>
																								<xsl:if test="../../cbc:TaxAmount/@currencyID != 'TRY'">
																									<xsl:value-of select="../../cbc:TaxAmount/@currencyID"/>
																								</xsl:if>
																							</xsl:if>
																						</xsl:for-each>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																	</xsl:if>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<tr align="right" id="budgetContainerTr">
											<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Vergiler Dahil Toplam Tutar</span>
														</span>
													</span>
												</span>
											</td>
											<td align="right" id="lineTableBudgetTd" style="width: 120px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:for-each select="//n1:Invoice">
																<xsl:for-each select="cac:LegalMonetaryTotal">
																	<xsl:for-each select="cbc:TaxInclusiveAmount">
																		<xsl:value-of select="format-number(., '###.##0,00', 'european')"/>
																		<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID">
																			<xsl:text/>
																			<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID = 'TRY'">
																				<xsl:text>TL</xsl:text>
																			</xsl:if>
																			<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID != 'TRY'">
																				<xsl:value-of select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:TaxInclusiveAmount/@currencyID"/>
																			</xsl:if>
																		</xsl:if>
																	</xsl:for-each>
																</xsl:for-each>
															</xsl:for-each>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr align="right" id="budgetContainerTr">
											<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Ödenecek Tutar</span>
														</span>
													</span>
												</span>
											</td>
											<td align="right" id="lineTableBudgetTd" style="width: 120px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:for-each select="//n1:Invoice">
																<xsl:for-each select="cac:LegalMonetaryTotal">
																	<xsl:for-each select="cbc:PayableAmount">
																		<xsl:value-of select="format-number(., '###.##0,00', 'european')"/>
																		<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID">
																			<xsl:text/>
																			<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID = 'TRY'">
																				<xsl:text>TL</xsl:text>
																			</xsl:if>
																			<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID != 'TRY'">
																				<xsl:value-of select="//n1:Invoice/cac:LegalMonetaryTotal/cbc:PayableAmount/@currencyID"/>
																			</xsl:if>
																		</xsl:if>
																	</xsl:for-each>
																</xsl:for-each>
															</xsl:for-each>
														</span>
													</span>
												</span>
											</td>
										</tr>
									</tbody>
								</table>
							</td>
						</tr>
						<tr>
							<td align="right">
								<xsl:if test="//n1:Invoice/cac:LegalMonetaryTotal/cbc:LineExtensionAmount/@currencyID != 'TRY'">
									<table border="1" bordercolor="#a4a4a4" cellpadding="0" cellspacing="0" id="budgetContainerTable" style="width: 371px;" width="500">
										<tbody>
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Döviz Kuru (</span>
																<strong>
																	<xsl:value-of select="//n1:Invoice/cac:PricingExchangeRate/cbc:TargetCurrencyCode"/>
																</strong>
																<span style="font-weight: bold;">)</span>
															</span>
														</span>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:value-of select="format-number(//n1:Invoice/cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,0000', 'european')"/>
																<xsl:text/>
																<xsl:text>TL</xsl:text>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Mal / Hizmet Toplam Tutarı</span>
															</span>
														</span>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																	<xsl:if test="cbc:DocumentType = 'LINEEXTENSIONAMOUNT'">
																		<xsl:value-of select="format-number(cbc:ID, '###.##0,00', 'european')"/>
																	</xsl:if>
																</xsl:for-each>
																<xsl:text/>
																<xsl:text>TL</xsl:text>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Toplam İskonto</span>
															</span>
														</span>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="color: rgb(105, 105, 105);">
																<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																	<xsl:if test="cbc:DocumentType = 'ALLOWANCETOTALAMOUNT'">
																		<xsl:value-of select="format-number(cbc:ID, '###.##0,00', 'european')"/>
																	</xsl:if>
																</xsl:for-each>
																<xsl:text/>
																<xsl:text>TL</xsl:text>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<xsl:if test="//n1:Invoice/cac:AllowanceCharge/cbc:MultiplierFactorNumeric">
												<tr align="right" id="budgetContainerTr">
													<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
														<span style="font-size: 10px;">
															<span style="color: rgb(105, 105, 105);">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<span style="font-weight: bold;">Toplam Masraf</span>
																</span>
															</span>
														</span>
													</td>
													<td align="right" id="lineTableBudgetTd" style="width: 120px;">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="color: rgb(105, 105, 105);"/>
															</span>
														</span>
													</td>
												</tr>
											</xsl:if>
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="color: rgb(105, 105, 105);">
														<strong>
															<span style="font-size: 10px;">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
																		<table id="taxSubtotalHeaderTable" cellpadding="0" cellspacing="0" width="100%" tagid="taxtable">
																			<tbody>
																				<tr align="right" style="width: 319px;">
																					<td width="100%" align="right">
																						<span style="font-weight:bold; ">
																							<xsl:choose>
																								<xsl:when test="cac:TaxCategory/cac:TaxScheme/cbc:Name=''">
																									<xsl:text>Diğer Vergiler Toplamı </xsl:text>
																								</xsl:when>
																								<xsl:otherwise>
																									<xsl:text>Hesaplanan </xsl:text>
																									<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name"/>
																								</xsl:otherwise>
																							</xsl:choose>
																							<xsl:text>(% </xsl:text>
																							<xsl:value-of select=" format-number(cbc:Percent, '###.##0,00', 'european')"/>
																							<xsl:text>) </xsl:text>
																						</span>
																					</td>
																				</tr>
																			</tbody>
																		</table>
																	</xsl:for-each>
																</span>
															</span>
														</strong>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="color: rgb(105, 105, 105);">
																<xsl:for-each select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal">
																	<xsl:variable name="var_Percent" select="cbc:Percent"/>
																	<xsl:variable name="var_TaxTypeCode" select="cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode"/>
																	<xsl:text/>
																	<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																		<xsl:variable name="var_DocumentType" select="cbc:DocumentType"/>
																		<xsl:variable name="var_DocumentTypeCode" select="cbc:DocumentTypeCode"/>
																		<xsl:if test="$var_DocumentType = $var_Percent and $var_DocumentTypeCode = $var_TaxTypeCode and not($var_Percent = '0.0000') ">
																			<table id="taxSubtotalsTable" border="0" cellpadding="0" cellspacing="0" align="right" tagid="taxtable" style="clear:both" width="100%">
																				<tbody>
																					<tr id="budgetContainerTr" align="right">
																						<td align="right">
																							<xsl:value-of select="format-number(cbc:ID, '###.##0,00', 'european')"/>
																							<xsl:text/>
																							<xsl:text>TL </xsl:text>
																						</td>
																					</tr>
																				</tbody>
																			</table>
																		</xsl:if>
																	</xsl:for-each>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="color: rgb(105, 105, 105);">
														<strong>
															<span style="font-size: 10px;">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<xsl:for-each select="//n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal">
																		<xsl:if test="not(cbc:Percent = 0.0000) or not(cbc:TaxAmount = 0)">
																			<table id="taxSubtotalHeaderTable" cellpadding="0" cellspacing="0" width="100%">
																				<tbody>
																					<tr align="right" style="width: 319px;" height="80">
																						<td width="100%" align="right" style="border-bottom: 1px solid #a4a4a4;">
																							<span style="font-weight:bold; ">
																								<xsl:choose>
																									<xsl:when test="cac:TaxCategory/cac:TaxScheme/cbc:Name=''">
																										<xsl:text>Diğer Vergiler Toplamı </xsl:text>
																									</xsl:when>
																									<xsl:otherwise>
																										<xsl:text>Tevkifat </xsl:text>
																										<xsl:value-of select="cac:TaxCategory/cac:TaxScheme/cbc:Name"/>
																									</xsl:otherwise>
																								</xsl:choose>
																								<xsl:text>(%</xsl:text>
																								<xsl:value-of select=" format-number(cbc:Percent, '###.##0,00', 'european')"/>
																								<xsl:text>)</xsl:text>
																							</span>
																						</td>
																					</tr>
																				</tbody>
																			</table>
																		</xsl:if>
																	</xsl:for-each>
																</span>
															</span>
														</strong>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="color: rgb(105, 105, 105);">
																<xsl:for-each select="//n1:Invoice/cac:WithholdingTaxTotal/cac:TaxSubtotal">
																	<xsl:variable name="var_Percent" select="cbc:Percent"/>
																	<xsl:variable name="var_TaxTypeCode" select="cac:TaxCategory/cac:TaxScheme/cbc:TaxTypeCode"/>
																	<xsl:text/>
																	<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																		<xsl:variable name="var_DocumentType" select="cbc:DocumentType"/>
																		<xsl:variable name="var_DocumentTypeCode" select="cbc:DocumentTypeCode"/>
																		<xsl:choose>
																			<xsl:when test="string(number($var_Percent)) != 'NaN' and string(number($var_DocumentType)) != 'NaN'">
																				<xsl:if test="(number($var_DocumentType) = number($var_Percent)) and $var_DocumentTypeCode = $var_TaxTypeCode and not(number($var_Percent) = 0) ">
																					<table id="taxSubtotalsTable" border="0" cellpadding="0" cellspacing="0" align="right" tagid="taxtable" style="clear:both" width="100%">
																						<tbody>
																							<tr id="budgetContainerTr" align="right" height="80">
																								<td align="right" style="border-bottom: 1px solid #a4a4a4;">
																									<xsl:value-of select="format-number(cbc:ID, '###.##0,00', 'european')"/>
																									<xsl:text/>
																									<xsl:text>TL </xsl:text>
																								</td>
																							</tr>
																						</tbody>
																					</table>
																				</xsl:if>
																			</xsl:when>
																			<xsl:otherwise>
																				<xsl:if test="$var_DocumentType = $var_Percent and $var_DocumentTypeCode = $var_TaxTypeCode and not($var_Percent = '0.0000') ">
																					<table id="taxSubtotalsTable" border="0" cellpadding="0" cellspacing="0" align="right" tagid="taxtable" style="clear:both" width="100%">
																						<tbody>
																							<tr id="budgetContainerTr" align="right" height="80">
																								<td align="right" style="border-bottom: 1px solid #a4a4a4;">
																									<xsl:value-of select="format-number(cbc:ID, '###.##0,00', 'european')"/>
																									<xsl:text/>
																									<xsl:text>TL </xsl:text>
																								</td>
																							</tr>
																						</tbody>
																					</table>
																				</xsl:if>
																			</xsl:otherwise>
																		</xsl:choose>
																	</xsl:for-each>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Vergiler Dahil Toplam Tutar</span>
															</span>
														</span>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="color: rgb(105, 105, 105);">
																<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																	<xsl:if test="cbc:DocumentType = 'TAXINCLUSIVEAMOUNT'">
																		<xsl:value-of select="format-number(cbc:ID, '###.##0,00', 'european')"/>
																	</xsl:if>
																</xsl:for-each>
																<xsl:text/>
																<xsl:text>TL</xsl:text>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Ödenecek Tutar</span>
															</span>
														</span>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="color: rgb(105, 105, 105);">
																<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																	<xsl:if test="cbc:DocumentType = 'PAYABLEAMOUNT'">
																		<xsl:value-of select="format-number(cbc:ID, '###.##0,00', 'european')"/>
																	</xsl:if>
																</xsl:for-each>
																<xsl:text/>
																<xsl:text>TL</xsl:text>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</tbody>
									</table>
								</xsl:if>
							</td>
						</tr>
					</tbody>
				</table>
				<xsl:if test="//n1:Invoice/cac:BillingReference/cac:AdditionalDocumentReference/cbc:DocumentTypeCode='OKCBF'">
					<table style="border: 2px solid rgb(0, 0, 0); border-image: none; width: 800px; border-collapse: collapse;">
						<thead>
							<tr>
								<th colspan="6">ÖKC Bilgileri</th>
							</tr>
						</thead>
						<tbody>
							<tr>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Fiş Numarası</span>
											</span>
										</strong>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Fiş Tarihi</span>
											</span>
										</strong>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Fiş Saati</span>
											</span>
										</strong>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Fiş Tipi</span>
											</span>
										</strong>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Z Rapor No</span>
											</span>
										</strong>
									</span>
								</td>
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">ÖKC Seri No</span>
											</span>
										</strong>
									</span>
								</td>
							</tr>
							<xsl:for-each select="//n1:Invoice/cac:BillingReference/cac:AdditionalDocumentReference/cbc:DocumentTypeCode[text()='OKCBF']">
								<tr>
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="../cbc:ID"/>
												</span>
											</span>
										</span>
									</td>
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="../cbc:IssueDate"/>
												</span>
											</span>
										</span>
									</td>
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="substring(../cac:ValidityPeriod/cbc:StartTime,1,5)"/>
												</span>
											</span>
										</span>
									</td>
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:choose>
														<xsl:when test="../cbc:DocumentDescription='AVANS'">
															<xsl:text>Ön Tahsilat(Avans) Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='YEMEK_FIS'">
															<xsl:text>Yemek Fişi/Kartı ile Yapılan Tahsilat Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='E-FATURA'">
															<xsl:text>E-Fatura Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='E-FATURA_IRSALIYE'">
															<xsl:text>İrsaliye Yerine Geçen E-Fatura Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='E-ARSIV'">
															<xsl:text>E-Arşiv Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='E-ARSIV_IRSALIYE'">
															<xsl:text>İrsaliye Yerine Geçen E-Arşiv Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='FATURA'">
															<xsl:text>Faturalı Satış Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='OTOPARK'">
															<xsl:text>Otopark Giriş Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='FATURA_TAHSILAT'">
															<xsl:text>Fatura Tahsilat Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:when test="../cbc:DocumentDescription='FATURA_TAHSILAT_KOMISYONLU'">
															<xsl:text>Komisyonlu Fatura Tahsilat Bilgi Fişi</xsl:text>
														</xsl:when>
														<xsl:otherwise>
															<xsl:text/>
														</xsl:otherwise>
													</xsl:choose>
												</span>
											</span>
										</span>
									</td>
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="../cac:Attachment/cac:ExternalReference/cbc:URI"/>
												</span>
											</span>
										</span>
									</td>
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="../cac:IssuerParty/cbc:EndpointID"/>
												</span>
											</span>
										</span>
									</td>
								</tr>
							</xsl:for-each>
						</tbody>
					</table>
				</xsl:if>
				<table border="1" cellpadding="0" cellspacing="0" style="width: 800px; ">
					<tbody>
						<tr>
							<td align="left">
								<p style="margin-left: 40px;">
									<br/>
									<span style="font-size: 11px;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: tahoma,geneva,sans-serif;">
												<xsl:if test="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:ID">
													<b>İban Numarası:</b>
													<xsl:value-of select="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:ID"/>
													<br/>
												</xsl:if>
												<xsl:if test="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:CurrencyCode">
													<b>Döviz Cinsi:</b>
													<xsl:value-of select="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:CurrencyCode"/>
													<br/>
												</xsl:if>
												<xsl:if test="//n1:Invoice/cac:PaymentMeans/cbc:InstructionNote">
													<b>Ödeme Notu:</b>
													<xsl:value-of select="//n1:Invoice/cac:PaymentMeans/cbc:InstructionNote"/>
													<br/>
												</xsl:if>
												<xsl:if test="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:PaymentNote">
													<b>Hesap Açıklaması:</b>
													<xsl:value-of select="//n1:Invoice/cac:PaymentMeans/cac:PayeeFinancialAccount/cbc:PaymentNote"/>
													<br/>
												</xsl:if>
												<xsl:if test="//n1:Invoice/cac:PaymentTerms/cbc:Note">
													<b>Ödeme Koşulu:</b>
													<xsl:value-of select="//n1:Invoice/cac:PaymentTerms/cbc:Note"/>
													<br/>
												</xsl:if>
												<xsl:if test="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cbc:TaxExemptionReason">
													<b>Vergi Muafiyet Sebebi</b>
													<xsl:value-of select="//n1:Invoice/cac:TaxTotal/cac:TaxSubtotal/cac:TaxCategory/cbc:TaxExemptionReason"/>
													<br/>
												</xsl:if>
												<br/>
												<xsl:if test="//n1:Invoice/cbc:Note">
													<b>Genel Açıklamalar</b>
													<br/>
													<xsl:for-each select="//n1:Invoice/cbc:Note">
														<xsl:if test=". and not(contains(.,'##BARCODE##'))">
															<b>       </b>
															<xsl:value-of select="."/>
															<br/>
														</xsl:if>
													</xsl:for-each>
												</xsl:if>
											
											</span>
										</span>
									</span>
								</p>
							</td>
						</tr>
					</tbody>
				</table>
        <table border="1" cellpadding="1" cellspacing="1" style="width:800px">
          <tbody>
            <tr>
              <td style="width:713px">
                <table border="1" cellpadding="1" cellspacing="1" style="width:798px">
                  <tbody>
                    <tr>
                      <td style="text-align:center; width:179px">
                        <p>
                          <span style="font-size:28px">
                            <strong>DESİ:</strong>
                          </span>
                          <span style="font-size:36px">
                            <strong ></strong>
                          </span>
                        </p>

                        <p>
                          <strong style="color:white">AAAAAA</strong>
                        </p>
                      </td>
                      <td style="text-align:center; width:295px">
                        <span style="font-size:28px">
                          <strong>PÖ.AT.KAPIDA.ÖDEME.NAKİT</strong>
                        </span>
                        <hr />
                        <span style="font-size:20px">
                          <strong style="color:white">AAAAAA</strong>
                        </span>
                      </td>
                      <td style="text-align:center; width:171px">
                        <strong>
                          <span style="font-size:28px">NAKİT</span>
                        </strong>
                      </td>
                    </tr>
                  </tbody>
                </table>

                <p></p>

                <p></p>
              </td>
            </tr>
            <tr> 
              <td align="left" style="width: 468px;padding-left:10px">
                <span style="color: black">
                  <span style="font-size: 16px;">
                    <span style="font-family: verdana,geneva,sans-serif;">
                   
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:for-each select="//n1:Invoice">
                              <xsl:for-each select="cac:AccountingCustomerParty">
                                <xsl:for-each select="cac:Party">
                                  <xsl:if test="cac:PartyName">
                                    <xsl:value-of select="cac:PartyName/cbc:Name"/>
                                    <br/>
                                  </xsl:if>
                                  <xsl:for-each select="cac:Person">
                                    <xsl:for-each select="cbc:Title">
                                      <xsl:apply-templates/>
                                      <span>
                                        <xsl:text> </xsl:text>
                                      </span>
                                    </xsl:for-each>
                                    <xsl:for-each select="cbc:FirstName">
                                      <xsl:apply-templates/>
                                      <span>
                                        <xsl:text> </xsl:text>
                                      </span>
                                    </xsl:for-each>
                                    <xsl:for-each select="cbc:MiddleName">
                                      <xsl:apply-templates/>
                                      <span>
                                        <xsl:text> </xsl:text>
                                      </span>
                                    </xsl:for-each>
                                    <xsl:for-each select="cbc:FamilyName">
                                      <xsl:apply-templates/>
                                      <span>
                                        <xsl:text> </xsl:text>
                                      </span>
                                    </xsl:for-each>
                                    <xsl:for-each select="cbc:NameSuffix">
                                      <xsl:apply-templates/>
                                    </xsl:for-each>
                                  </xsl:for-each>
                                </xsl:for-each>
                              </xsl:for-each>
                            </xsl:for-each>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:for-each select="//n1:Invoice">
                              <xsl:for-each select="cac:BuyerCustomerParty">
                                <xsl:for-each select="cac:Party">
                                  <xsl:if test="cac:PartyName">
                                    <xsl:value-of select="cac:PartyName/cbc:Name"/>
                                    <br/>
                                  </xsl:if>
                                  <xsl:for-each select="cac:Person">
                                    <xsl:for-each select="cbc:Title">
                                      <xsl:apply-templates/>
                                      <span>
                                        <xsl:text> </xsl:text>
                                      </span>
                                    </xsl:for-each>
                                    <xsl:for-each select="cbc:FirstName">
                                      <xsl:apply-templates/>
                                      <span>
                                        <xsl:text> </xsl:text>
                                      </span>
                                    </xsl:for-each>
                                    <xsl:for-each select="cbc:MiddleName">
                                      <xsl:apply-templates/>
                                      <span>
                                        <xsl:text> </xsl:text>
                                      </span>
                                    </xsl:for-each>
                                    <xsl:for-each select="cbc:FamilyName">
                                      <xsl:apply-templates/>
                                      <span>
                                        <xsl:text> </xsl:text>
                                      </span>
                                    </xsl:for-each>
                                    <xsl:for-each select="cbc:NameSuffix">
                                      <xsl:apply-templates/>
                                    </xsl:for-each>
                                  </xsl:for-each>
                                </xsl:for-each>
                              </xsl:for-each>
                            </xsl:for-each>
                          </xsl:otherwise>
                        </xsl:choose>
                    
                    </span>
                  </span>
                </span>
                <span style="color: black;padding-left:20px">
                  <span style="font-size: 16px;">
                    <span style="font-family: verdana,geneva,sans-serif;">
                      <xsl:choose>
                        <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                          <xsl:if test="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telephone !=''">
                            <xsl:text>  </xsl:text>
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:Contact/cbc:Telephone"/>
                          </xsl:if>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:if test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telephone != ''">
                            <xsl:text>  </xsl:text>
                            <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Contact/cbc:Telephone"/>
                          </xsl:if>
                        </xsl:otherwise>
                      </xsl:choose>
               
                    </span>
                  </span>
                </span>
       
              </td>
          
            </tr>
            
              <tr align="left">
                <td align="left" style="width: 469px;padding-left:10px">
                  <span style="color: black">
                    <span style="font-size: 16px;">
                      <span style="font-family: verdana,geneva,sans-serif;">
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:StreetName"/>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:StreetName"/>
                          </xsl:otherwise>
                        </xsl:choose>
                        <br/>
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:BuildingName"/>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:BuildingName"/>
                          </xsl:otherwise>
                        </xsl:choose>
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:BuildingNumber"/>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:BuildingNumber"/>
                          </xsl:otherwise>
                        </xsl:choose>
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:Room"/>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="n1:Invoice/cac:PostalAddress/cac:Party/cac:PostalAddress/cbc:Room"/>
                          </xsl:otherwise>
                        </xsl:choose>
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:Region"/>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:Region"/>
                          </xsl:otherwise>
                        </xsl:choose>
                        <br/>
                      
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:PostalZone"/>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:PostalZone"/>
                          </xsl:otherwise>
                        </xsl:choose>
                       
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:CitySubdivisionName"/>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CitySubdivisionName"/>
                          </xsl:otherwise>
                        </xsl:choose>
                        /
                        <xsl:choose>
                          <xsl:when test="not(//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA' or //n1:Invoice/cbc:ProfileID = 'IHRACAT')">
                            <xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cbc:CityName"/>
                          </xsl:when>
                          <xsl:otherwise>
                            <xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cbc:CityName"/>
                          </xsl:otherwise>
                        </xsl:choose>
                      </span>
                    </span>
                  </span>
                </td>
              </tr>
          
          </tbody>
        </table>
				<xsl:if test="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'EINVOICE']/cbc:DocumentType=3">
					<table border="1" cellpadding="0" cellspacing="0" style="width: 800px;">
						<tbody>
							<tr>
								<td>
									<p>
										<span style="font-size: 11px;">
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: tahoma,geneva,sans-serif;">
													<strong>           İnternet Satış Bilgileri:</strong>
												</span>
											</span>
										</span>
										<br/>
										<span style="font-size: 11px;">
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: tahoma,geneva,sans-serif;">           Bu satış internet üzerinden yapılmıştır.</span>
											</span>
										</span>
										<br/>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/webAdresi']/cbc:DocumentType)">
											<span style="margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Satış İşleminin Yapıldığı Web Adresi: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/webAdresi']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/odemeAracisiAdi']/cbc:DocumentType)">
											<span style="margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Ödeme Aracısı: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/odemeAracisiAdi']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
										<br/>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/odemeSekli']/cbc:DocumentType)">
											<span style="line-height: 1.6em; margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Ödeme şekli: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/odemeSekli']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/odemeTarihi']/cbc:DocumentType)">
											<span style="line-height: 1.6em; margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Ödeme Tarihi: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/odemeTarihi']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderimTarihi']/cbc:DocumentType)">
											<span style="line-height: 1.6em; margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Gönderim Tarihi: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderimTarihi']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
										<br/>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderiTasiyan/gercekKisi/tckn']/cbc:DocumentType)">
											<span style="line-height: 1.6em; margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Gönderiyi taşıyan TCKN: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderiTasiyan/gercekKisi/tckn']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderiTasiyan/tuzelKisi/vkn']/cbc:DocumentType)">
											<span style="line-height: 1.6em; margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Gönderiyi taşıyan VKN: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderiTasiyan/tuzelKisi/vkn']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderiTasiyan/gercekKisi/adiSoyadi']/cbc:DocumentType)">
											<span style="line-height: 1.6em; margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Gönderiyi taşıyan adı soyadı: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderiTasiyan/gercekKisi/adiSoyadi']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
										<xsl:if test="normalize-space(//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderiTasiyan/tuzelKisi/unvan']/cbc:DocumentType)">
											<span style="margin-left: 40px;">
												<span style="font-size: 11px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: tahoma,geneva,sans-serif;">
															<strong>Gönderiyi taşıyan unvanı: </strong>
															<xsl:value-of select="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID = 'internetSatisBilgi/gonderiBilgileri/gonderiTasiyan/tuzelKisi/unvan']/cbc:DocumentType"/>
														</span>
													</span>
												</span>
											</span>
										</xsl:if>
									</p>
									<xsl:if test="//n1:Invoice/cac:AdditionalDocumentReference/cbc:ID ='EINVOICE' and //n1:Invoice/cac:AdditionalDocumentReference/cbc:DocumentType =3">
										<table border="0" cellpadding="0" cellspacing="0">
											<tbody>
												<tr>
													<td>
														<span style="margin-left: 40px;">
															<span style="font-size: 11px;">
																<span style="color: rgb(105, 105, 105);">
																	<span style="font-family: tahoma,geneva,sans-serif;">
																		<strong>     İade Bölümü</strong>
																	</span>
																</span>
															</span>
														</span>
														<table border="1" bordercolor="#a4a4a4" cellpadding="0" cellspacing="0" style="margin-left: 40px;">
															<tbody>
																<tr id="budgetContainerTr">
																	<td id="lineTableBudgetTd" style="width: 290px;">
																		<span style="margin-left: 40px;">
																			<span style="font-size: 11px;">
																				<span style="color: rgb(105, 105, 105);">
																					<span style="font-family: tahoma,geneva,sans-serif;">
																						<span style="font-weight: bold;">Malın Cinsi</span>
																					</span>
																				</span>
																			</span>
																		</span>
																	</td>
																	<td id="lineTableBudgetTd" style="width: 100px;">
																		<span style="margin-left: 40px;">
																			<span style="font-size: 11px;">
																				<span style="color: rgb(105, 105, 105);">
																					<span style="font-family: tahoma,geneva,sans-serif;">
																						<span style="font-weight: bold;">Malın Miktarı</span>
																					</span>
																				</span>
																			</span>
																		</span>
																	</td>
																	<td id="lineTableBudgetTd" style="width: 150px;">
																		<span style="margin-left: 40px;">
																			<span style="font-size: 11px;">
																				<span style="color: rgb(105, 105, 105);">
																					<span style="font-family: tahoma,geneva,sans-serif;">
																						<span style="font-weight: bold;">Birim Fiyatı</span>
																					</span>
																				</span>
																			</span>
																		</span>
																	</td>
																	<td id="lineTableBudgetTd" style="width: 150px;">
																		<span style="margin-left: 40px;">
																			<span style="font-size: 11px;">
																				<span style="color: rgb(105, 105, 105);">
																					<span style="font-family: tahoma,geneva,sans-serif;">
																						<span style="font-weight: bold;">Tutar</span>
																					</span>
																				</span>
																			</span>
																		</span>
																	</td>
																</tr>
																<tr id="budgetContainerTr">
																	<td id="lineTableBudgetTd">
																		<span style="margin-left: 40px;"> </span>
																	</td>
																	<td id="lineTableBudgetTd">
																		<span style="margin-left: 40px;"> </span>
																	</td>
																	<td id="lineTableBudgetTd">
																		<span style="margin-left: 40px;"> </span>
																	</td>
																	<td id="lineTableBudgetTd">
																		<span style="margin-left: 40px;"> </span>
																	</td>
																</tr>
																<tr id="budgetContainerTr">
																	<td id="lineTableBudgetTd">
																		<span style="margin-left: 40px;"> </span>
																	</td>
																	<td id="lineTableBudgetTd">
																		<span style="margin-left: 40px;"> </span>
																	</td>
																	<td id="lineTableBudgetTd">
																		<span style="margin-left: 40px;"> </span>
																	</td>
																	<td id="lineTableBudgetTd">
																		<span style="margin-left: 40px;"> </span>
																	</td>
																</tr>
															</tbody>
														</table>
														<span style="margin-left: 40px;">
															<span style="font-size: 11px;">
																<span style="color: rgb(105, 105, 105);">
																	<span style="font-family: tahoma,geneva,sans-serif;">
																		<span style="font-weight: bold;">     Malı İade Edenin:</span>
																	</span>
																</span>
															</span>
															<span style="font-size: 11px;">
																<span style="color: rgb(105, 105, 105);">
																	<span style="font-family: tahoma,geneva,sans-serif;">
																		<span style="font-weight: bold;">     Adı Soyadı</span>
																	</span>
																</span>
															</span>
															<span style="font-size: 11px;">
																<span style="color: rgb(105, 105, 105);">
																	<span style="font-family: tahoma,geneva,sans-serif;">
																		<span style="font-weight: bold;">                                                  Adresi                                                  </span>
																	</span>
																</span>
															</span>
															<span style="font-size: 11px;">
																<span style="color: rgb(105, 105, 105);">
																	<span style="font-family: tahoma,geneva,sans-serif;">
																		<span style="font-weight: bold;">     İmzası</span>
																	</span>
																</span>
															</span>
															<br/>
															<br/>
															<br/>
														</span>
														<span style="margin-left: 40px;"/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:if>
								</td>
							</tr>
						</tbody>
					</table>
				</xsl:if>
				<table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
					<tbody>
						<tr>
							<td>
								<xsl:if test="//n1:Invoice/cac:AdditionalDocumentReference[cbc:ID ='gonderimSekli']/cbc:DocumentType ='ELEKTRONIK'">
									<div style="text-align: center;">
										<span style="margin-left: 40px;">
											<span style="font-size: 11px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-family: tahoma,geneva,sans-serif;">e-Arşiv izni kapsamında elektronik ortamda iletilmiştir.</span>
												</span>
											</span>
										</span>
									</div>
								</xsl:if>
								<xsl:if test="not(//n1:Invoice/cac:DespatchDocumentReference) and //n1:Invoice/cbc:ProfileID !='IHRACAT'">
									<div style="text-align: center;">
										<span style="margin-left: 40px;">
											<span style="font-size: 11px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-family: tahoma,geneva,sans-serif;">İrsaliye yerine geçer.</span>
												</span>
											</span>
										</span>
									</div>
								</xsl:if>
							</td>
						</tr>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
	<xsl:template name="TransportMode">
		<xsl:param name="TransportModeType"/>
		<xsl:choose>
			<xsl:when test="$TransportModeType=1">Denizyolu</xsl:when>
			<xsl:when test="$TransportModeType=2">Demiryolu</xsl:when>
			<xsl:when test="$TransportModeType=3">Karayolu</xsl:when>
			<xsl:when test="$TransportModeType=4">Havayolu</xsl:when>
			<xsl:when test="$TransportModeType=5">Posta</xsl:when>
			<xsl:when test="$TransportModeType=6">Çok araçlı</xsl:when>
			<xsl:when test="$TransportModeType=7">Sabit taşıma tesisleri</xsl:when>
			<xsl:when test="$TransportModeType=8">İç su taşımacılığı</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$TransportModeType"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
	<xsl:template name="geneliskonto">
		<tr id="lineTableTr">
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="left">
				<span>
					<table border="0">
						<tbody>
							<xsl:for-each select="//n1:Invoice/cac:AllowanceCharge">
								<tr>
									<td>
										<xsl:text>     </xsl:text>
										<xsl:text>İndirim</xsl:text>
									</td>
								</tr>
							</xsl:for-each>
						</tbody>
					</table>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<table border="0">
						<tbody>
							<xsl:for-each select="//n1:Invoice/cac:AllowanceCharge">
								<tr>
									<td>
										<xsl:choose>
											<xsl:when test="normalize-space(cbc:AllowanceChargeReason)">
												<xsl:value-of select="cbc:AllowanceChargeReason"/>
											</xsl:when>
											<xsl:otherwise>
												<xsl:if test="normalize-space(cbc:MultiplierFactorNumeric)">
													<xsl:text>%</xsl:text>
													<xsl:value-of select="format-number(cbc:MultiplierFactorNumeric*100, '###.##0,00', 'european')"/>
												</xsl:if>
											</xsl:otherwise>
										</xsl:choose>
									</td>
								</tr>
							</xsl:for-each>
						</tbody>
					</table>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<table border="0">
						<tbody>
							<xsl:for-each select="//n1:Invoice/cac:AllowanceCharge">
								<tr>
									<td>
										<xsl:value-of select="format-number(cbc:Amount, '###.##0,00', 'european')"/>
										<xsl:if test="cbc:Amount/@currencyID">
											<xsl:text/>
											<xsl:if test="cbc:Amount/@currencyID = 'TRY'">
												<xsl:text>TL</xsl:text>
											</xsl:if>
											<xsl:if test="cbc:Amount/@currencyID != 'TRY'">
												<xsl:value-of select="cbc:Amount/@currencyID"/>
											</xsl:if>
										</xsl:if>
									</td>
								</tr>
							</xsl:for-each>
						</tbody>
					</table>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
			<td id="lineTableTd" style="border-top:thick double black; border-top-width:3px;" align="right">
				<span>
					<xsl:text> </xsl:text>
				</span>
			</td>
		</tr>
	</xsl:template>
	<xsl:template name="Country">
		<xsl:param name="CountryType"/>
		<xsl:choose>
			<xsl:when test="$CountryType='AF'">Afganistan</xsl:when>
			<xsl:when test="$CountryType='DE'">Almanya</xsl:when>
			<xsl:when test="$CountryType='AD'">Andorra</xsl:when>
			<xsl:when test="$CountryType='AO'">Angola</xsl:when>
			<xsl:when test="$CountryType='AG'">Antigua ve Barbuda</xsl:when>
			<xsl:when test="$CountryType='AR'">Arjantin</xsl:when>
			<xsl:when test="$CountryType='AL'">Arnavutluk</xsl:when>
			<xsl:when test="$CountryType='AW'">Aruba</xsl:when>
			<xsl:when test="$CountryType='AU'">Avustralya</xsl:when>
			<xsl:when test="$CountryType='AT'">Avusturya</xsl:when>
			<xsl:when test="$CountryType='AZ'">Azerbaycan</xsl:when>
			<xsl:when test="$CountryType='BS'">Bahamalar</xsl:when>
			<xsl:when test="$CountryType='BH'">Bahreyn</xsl:when>
			<xsl:when test="$CountryType='BD'">Bangladeş</xsl:when>
			<xsl:when test="$CountryType='BB'">Barbados</xsl:when>
			<xsl:when test="$CountryType='EH'">Batı Sahra (MA)</xsl:when>
			<xsl:when test="$CountryType='BE'">Belçika</xsl:when>
			<xsl:when test="$CountryType='BZ'">Belize</xsl:when>
			<xsl:when test="$CountryType='BJ'">Benin</xsl:when>
			<xsl:when test="$CountryType='BM'">Bermuda</xsl:when>
			<xsl:when test="$CountryType='BY'">Beyaz Rusya</xsl:when>
			<xsl:when test="$CountryType='BT'">Bhutan</xsl:when>
			<xsl:when test="$CountryType='AE'">Birleşik Arap Emirlikleri</xsl:when>
			<xsl:when test="$CountryType='US'">Birleşik Devletler</xsl:when>
			<xsl:when test="$CountryType='GB'">Birleşik Krallık</xsl:when>
			<xsl:when test="$CountryType='BO'">Bolivya</xsl:when>
			<xsl:when test="$CountryType='BA'">Bosna-Hersek</xsl:when>
			<xsl:when test="$CountryType='BW'">Botsvana</xsl:when>
			<xsl:when test="$CountryType='BR'">Brezilya</xsl:when>
			<xsl:when test="$CountryType='BN'">Bruney</xsl:when>
			<xsl:when test="$CountryType='BG'">Bulgaristan</xsl:when>
			<xsl:when test="$CountryType='BF'">Burkina Faso</xsl:when>
			<xsl:when test="$CountryType='BI'">Burundi</xsl:when>
			<xsl:when test="$CountryType='TD'">Çad</xsl:when>
			<xsl:when test="$CountryType='KY'">Cayman Adaları</xsl:when>
			<xsl:when test="$CountryType='GI'">Cebelitarık (GB)</xsl:when>
			<xsl:when test="$CountryType='CZ'">Çek Cumhuriyeti</xsl:when>
			<xsl:when test="$CountryType='DZ'">Cezayir</xsl:when>
			<xsl:when test="$CountryType='DJ'">Cibuti</xsl:when>
			<xsl:when test="$CountryType='CN'">Çin</xsl:when>
			<xsl:when test="$CountryType='DK'">Danimarka</xsl:when>
			<xsl:when test="$CountryType='CD'">Demokratik Kongo Cumhuriyeti</xsl:when>
			<xsl:when test="$CountryType='TL'">Doğu Timor</xsl:when>
			<xsl:when test="$CountryType='DO'">Dominik Cumhuriyeti</xsl:when>
			<xsl:when test="$CountryType='DM'">Dominika</xsl:when>
			<xsl:when test="$CountryType='EC'">Ekvador</xsl:when>
			<xsl:when test="$CountryType='GQ'">Ekvator Ginesi</xsl:when>
			<xsl:when test="$CountryType='SV'">El Salvador</xsl:when>
			<xsl:when test="$CountryType='ID'">Endonezya</xsl:when>
			<xsl:when test="$CountryType='ER'">Eritre</xsl:when>
			<xsl:when test="$CountryType='AM'">Ermenistan</xsl:when>
			<xsl:when test="$CountryType='MF'">Ermiş Martin (FR)</xsl:when>
			<xsl:when test="$CountryType='EE'">Estonya</xsl:when>
			<xsl:when test="$CountryType='ET'">Etiyopya</xsl:when>
			<xsl:when test="$CountryType='FK'">Falkland Adaları</xsl:when>
			<xsl:when test="$CountryType='FO'">Faroe Adaları (DK)</xsl:when>
			<xsl:when test="$CountryType='MA'">Fas</xsl:when>
			<xsl:when test="$CountryType='FJ'">Fiji</xsl:when>
			<xsl:when test="$CountryType='CI'">Fildişi Sahili</xsl:when>
			<xsl:when test="$CountryType='PH'">Filipinler</xsl:when>
			<xsl:when test="$CountryType='FI'">Finlandiya</xsl:when>
			<xsl:when test="$CountryType='FR'">Fransa</xsl:when>
			<xsl:when test="$CountryType='GF'">Fransız Guyanası (FR)</xsl:when>
			<xsl:when test="$CountryType='PF'">Fransız Polinezyası (FR)</xsl:when>
			<xsl:when test="$CountryType='GA'">Gabon</xsl:when>
			<xsl:when test="$CountryType='GM'">Gambiya</xsl:when>
			<xsl:when test="$CountryType='GH'">Gana</xsl:when>
			<xsl:when test="$CountryType='GN'">Gine</xsl:when>
			<xsl:when test="$CountryType='GW'">Gine Bissau</xsl:when>
			<xsl:when test="$CountryType='GD'">Grenada</xsl:when>
			<xsl:when test="$CountryType='GL'">Grönland (DK)</xsl:when>
			<xsl:when test="$CountryType='GP'">Guadeloupe (FR)</xsl:when>
			<xsl:when test="$CountryType='GT'">Guatemala</xsl:when>
			<xsl:when test="$CountryType='GG'">Guernsey (GB)</xsl:when>
			<xsl:when test="$CountryType='ZA'">Güney Afrika</xsl:when>
			<xsl:when test="$CountryType='KR'">Güney Kore</xsl:when>
			<xsl:when test="$CountryType='GE'">Gürcistan</xsl:when>
			<xsl:when test="$CountryType='GY'">Guyana</xsl:when>
			<xsl:when test="$CountryType='HT'">Haiti</xsl:when>
			<xsl:when test="$CountryType='IN'">Hindistan</xsl:when>
			<xsl:when test="$CountryType='HR'">Hırvatistan</xsl:when>
			<xsl:when test="$CountryType='NL'">Hollanda</xsl:when>
			<xsl:when test="$CountryType='HN'">Honduras</xsl:when>
			<xsl:when test="$CountryType='HK'">Hong Kong (CN)</xsl:when>
			<xsl:when test="$CountryType='VG'">İngiliz Virjin Adaları</xsl:when>
			<xsl:when test="$CountryType='IQ'">Irak</xsl:when>
			<xsl:when test="$CountryType='IR'">İran</xsl:when>
			<xsl:when test="$CountryType='IE'">İrlanda</xsl:when>
			<xsl:when test="$CountryType='ES'">İspanya</xsl:when>
			<xsl:when test="$CountryType='IL'">İsrail</xsl:when>
			<xsl:when test="$CountryType='SE'">İsveç</xsl:when>
			<xsl:when test="$CountryType='CH'">İsviçre</xsl:when>
			<xsl:when test="$CountryType='IT'">İtalya</xsl:when>
			<xsl:when test="$CountryType='IS'">İzlanda</xsl:when>
			<xsl:when test="$CountryType='JM'">Jamaika</xsl:when>
			<xsl:when test="$CountryType='JP'">Japonya</xsl:when>
			<xsl:when test="$CountryType='JE'">Jersey (GB)</xsl:when>
			<xsl:when test="$CountryType='KH'">Kamboçya</xsl:when>
			<xsl:when test="$CountryType='CM'">Kamerun</xsl:when>
			<xsl:when test="$CountryType='CA'">Kanada</xsl:when>
			<xsl:when test="$CountryType='ME'">Karadağ</xsl:when>
			<xsl:when test="$CountryType='QA'">Katar</xsl:when>
			<xsl:when test="$CountryType='KZ'">Kazakistan</xsl:when>
			<xsl:when test="$CountryType='KE'">Kenya</xsl:when>
			<xsl:when test="$CountryType='CY'">Kıbrıs</xsl:when>
			<xsl:when test="$CountryType='KG'">Kırgızistan</xsl:when>
			<xsl:when test="$CountryType='KI'">Kiribati</xsl:when>
			<xsl:when test="$CountryType='CO'">Kolombiya</xsl:when>
			<xsl:when test="$CountryType='KM'">Komorlar</xsl:when>
			<xsl:when test="$CountryType='CG'">Kongo Cumhuriyeti</xsl:when>
			<xsl:when test="$CountryType='KV'">Kosova (RS)</xsl:when>
			<xsl:when test="$CountryType='CR'">Kosta Rika</xsl:when>
			<xsl:when test="$CountryType='CU'">Küba</xsl:when>
			<xsl:when test="$CountryType='KW'">Kuveyt</xsl:when>
			<xsl:when test="$CountryType='KP'">Kuzey Kore</xsl:when>
			<xsl:when test="$CountryType='LA'">Laos</xsl:when>
			<xsl:when test="$CountryType='LS'">Lesoto</xsl:when>
			<xsl:when test="$CountryType='LV'">Letonya</xsl:when>
			<xsl:when test="$CountryType='LR'">Liberya</xsl:when>
			<xsl:when test="$CountryType='LY'">Libya</xsl:when>
			<xsl:when test="$CountryType='LI'">Lihtenştayn</xsl:when>
			<xsl:when test="$CountryType='LT'">Litvanya</xsl:when>
			<xsl:when test="$CountryType='LB'">Lübnan</xsl:when>
			<xsl:when test="$CountryType='LU'">Lüksemburg</xsl:when>
			<xsl:when test="$CountryType='HU'">Macaristan</xsl:when>
			<xsl:when test="$CountryType='MG'">Madagaskar</xsl:when>
			<xsl:when test="$CountryType='MO'">Makao (CN)</xsl:when>
			<xsl:when test="$CountryType='MK'">Makedonya</xsl:when>
			<xsl:when test="$CountryType='MW'">Malavi</xsl:when>
			<xsl:when test="$CountryType='MV'">Maldivler</xsl:when>
			<xsl:when test="$CountryType='MY'">Malezya</xsl:when>
			<xsl:when test="$CountryType='ML'">Mali</xsl:when>
			<xsl:when test="$CountryType='MT'">Malta</xsl:when>
			<xsl:when test="$CountryType='IM'">Man Adası (GB)</xsl:when>
			<xsl:when test="$CountryType='MH'">Marshall Adaları</xsl:when>
			<xsl:when test="$CountryType='MQ'">Martinique (FR)</xsl:when>
			<xsl:when test="$CountryType='MU'">Mauritius</xsl:when>
			<xsl:when test="$CountryType='YT'">Mayotte (FR)</xsl:when>
			<xsl:when test="$CountryType='MX'">Meksika</xsl:when>
			<xsl:when test="$CountryType='FM'">Mikronezya</xsl:when>
			<xsl:when test="$CountryType='EG'">Mısır</xsl:when>
			<xsl:when test="$CountryType='MN'">Moğolistan</xsl:when>
			<xsl:when test="$CountryType='MD'">Moldova</xsl:when>
			<xsl:when test="$CountryType='MC'">Monako</xsl:when>
			<xsl:when test="$CountryType='MR'">Moritanya</xsl:when>
			<xsl:when test="$CountryType='MZ'">Mozambik</xsl:when>
			<xsl:when test="$CountryType='MM'">Myanmar</xsl:when>
			<xsl:when test="$CountryType='NA'">Namibya</xsl:when>
			<xsl:when test="$CountryType='NR'">Nauru</xsl:when>
			<xsl:when test="$CountryType='NP'">Nepal</xsl:when>
			<xsl:when test="$CountryType='NE'">Nijer</xsl:when>
			<xsl:when test="$CountryType='NG'">Nijerya</xsl:when>
			<xsl:when test="$CountryType='NI'">Nikaragua</xsl:when>
			<xsl:when test="$CountryType='NO'">Norveç</xsl:when>
			<xsl:when test="$CountryType='CF'">Orta Afrika Cumhuriyeti</xsl:when>
			<xsl:when test="$CountryType='UZ'">Özbekistan</xsl:when>
			<xsl:when test="$CountryType='PK'">Pakistan</xsl:when>
			<xsl:when test="$CountryType='PW'">Palau</xsl:when>
			<xsl:when test="$CountryType='PA'">Panama</xsl:when>
			<xsl:when test="$CountryType='PG'">Papua Yeni Gine</xsl:when>
			<xsl:when test="$CountryType='PY'">Paraguay</xsl:when>
			<xsl:when test="$CountryType='PE'">Peru</xsl:when>
			<xsl:when test="$CountryType='PL'">Polonya</xsl:when>
			<xsl:when test="$CountryType='PT'">Portekiz</xsl:when>
			<xsl:when test="$CountryType='PR'">Porto Riko (US)</xsl:when>
			<xsl:when test="$CountryType='RE'">Réunion (FR)</xsl:when>
			<xsl:when test="$CountryType='RO'">Romanya</xsl:when>
			<xsl:when test="$CountryType='RW'">Ruanda</xsl:when>
			<xsl:when test="$CountryType='RU'">Rusya</xsl:when>
			<xsl:when test="$CountryType='BL'">Saint Barthélemy (FR)</xsl:when>
			<xsl:when test="$CountryType='KN'">Saint Kitts ve Nevis</xsl:when>
			<xsl:when test="$CountryType='LC'">Saint Lucia</xsl:when>
			<xsl:when test="$CountryType='PM'">Saint Pierre ve Miquelon (FR)</xsl:when>
			<xsl:when test="$CountryType='VC'">Saint Vincent ve Grenadinler</xsl:when>
			<xsl:when test="$CountryType='WS'">Samoa</xsl:when>
			<xsl:when test="$CountryType='SM'">San Marino</xsl:when>
			<xsl:when test="$CountryType='ST'">São Tomé ve Príncipe</xsl:when>
			<xsl:when test="$CountryType='SN'">Senegal</xsl:when>
			<xsl:when test="$CountryType='SC'">Seyşeller</xsl:when>
			<xsl:when test="$CountryType='SL'">Sierra Leone</xsl:when>
			<xsl:when test="$CountryType='CL'">Şili</xsl:when>
			<xsl:when test="$CountryType='SG'">Singapur</xsl:when>
			<xsl:when test="$CountryType='RS'">Sırbistan</xsl:when>
			<xsl:when test="$CountryType='SK'">Slovakya Cumhuriyeti</xsl:when>
			<xsl:when test="$CountryType='SI'">Slovenya</xsl:when>
			<xsl:when test="$CountryType='SB'">Solomon Adaları</xsl:when>
			<xsl:when test="$CountryType='SO'">Somali</xsl:when>
			<xsl:when test="$CountryType='SS'">South Sudan</xsl:when>
			<xsl:when test="$CountryType='SJ'">Spitsbergen (NO)</xsl:when>
			<xsl:when test="$CountryType='LK'">Sri Lanka</xsl:when>
			<xsl:when test="$CountryType='SD'">Sudan</xsl:when>
			<xsl:when test="$CountryType='SR'">Surinam</xsl:when>
			<xsl:when test="$CountryType='SY'">Suriye</xsl:when>
			<xsl:when test="$CountryType='SA'">Suudi Arabistan</xsl:when>
			<xsl:when test="$CountryType='SZ'">Svaziland</xsl:when>
			<xsl:when test="$CountryType='TJ'">Tacikistan</xsl:when>
			<xsl:when test="$CountryType='TZ'">Tanzanya</xsl:when>
			<xsl:when test="$CountryType='TH'">Tayland</xsl:when>
			<xsl:when test="$CountryType='TW'">Tayvan</xsl:when>
			<xsl:when test="$CountryType='TG'">Togo</xsl:when>
			<xsl:when test="$CountryType='TO'">Tonga</xsl:when>
			<xsl:when test="$CountryType='TT'">Trinidad ve Tobago</xsl:when>
			<xsl:when test="$CountryType='TN'">Tunus</xsl:when>
			<xsl:when test="$CountryType='TR'">Türkiye</xsl:when>
			<xsl:when test="$CountryType='TM'">Türkmenistan</xsl:when>
			<xsl:when test="$CountryType='TC'">Turks ve Caicos</xsl:when>
			<xsl:when test="$CountryType='TV'">Tuvalu</xsl:when>
			<xsl:when test="$CountryType='UG'">Uganda</xsl:when>
			<xsl:when test="$CountryType='UA'">Ukrayna</xsl:when>
			<xsl:when test="$CountryType='OM'">Umman</xsl:when>
			<xsl:when test="$CountryType='JO'">Ürdün</xsl:when>
			<xsl:when test="$CountryType='UY'">Uruguay</xsl:when>
			<xsl:when test="$CountryType='VU'">Vanuatu</xsl:when>
			<xsl:when test="$CountryType='VA'">Vatikan</xsl:when>
			<xsl:when test="$CountryType='VE'">Venezuela</xsl:when>
			<xsl:when test="$CountryType='VN'">Vietnam</xsl:when>
			<xsl:when test="$CountryType='WF'">Wallis ve Futuna (FR)</xsl:when>
			<xsl:when test="$CountryType='YE'">Yemen</xsl:when>
			<xsl:when test="$CountryType='NC'">Yeni Kaledonya (FR)</xsl:when>
			<xsl:when test="$CountryType='NZ'">Yeni Zelanda</xsl:when>
			<xsl:when test="$CountryType='CV'">Yeşil Burun Adaları</xsl:when>
			<xsl:when test="$CountryType='GR'">Yunanistan</xsl:when>
			<xsl:when test="$CountryType='ZM'">Zambiya</xsl:when>
			<xsl:when test="$CountryType='ZW'">Zimbabve</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$CountryType"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
</xsl:stylesheet>
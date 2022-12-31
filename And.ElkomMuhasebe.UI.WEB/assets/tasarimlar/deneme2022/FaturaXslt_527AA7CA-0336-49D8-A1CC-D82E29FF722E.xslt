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
				<p>
					<span style="font-size: 10px;">​​</span>
				</p>
				<table border="0" cellpadding="0" cellspacing="0" style="border-color: blue;" width="800">
					<tbody>
						<tr>
							<td style="width: 205px;">
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
							<td style="width: 200px; text-align: center;">
								<span style="font-size: 10px;">
									<span style="color: rgb(105, 105, 105);">
										<span style="font-family: verdana,geneva,sans-serif;">
											<img align="middle" alt="GIB Logo" src="data:image/jpeg;base64,/9j/4QAYRXhpZgAASUkqAAgAAAAAAAAAAAAAAP/sABFEdWNreQABAAQAAABkAAD/4QMZaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLwA8P3hwYWNrZXQgYmVnaW49Iu+7vyIgaWQ9Ilc1TTBNcENlaGlIenJlU3pOVGN6a2M5ZCI/PiA8eDp4bXBtZXRhIHhtbG5zOng9ImFkb2JlOm5zOm1ldGEvIiB4OnhtcHRrPSJBZG9iZSBYTVAgQ29yZSA1LjYtYzEzMiA3OS4xNTkyODQsIDIwMTYvMDQvMTktMTM6MTM6NDAgICAgICAgICI+IDxyZGY6UkRGIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyI+IDxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSIiIHhtbG5zOnhtcE1NPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vIiB4bWxuczpzdFJlZj0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL3NUeXBlL1Jlc291cmNlUmVmIyIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bXBNTTpEb2N1bWVudElEPSJ4bXAuZGlkOjZDNDJBNEI2QjVCRDExRThCQjM0REIwQkZGMEQxODY0IiB4bXBNTTpJbnN0YW5jZUlEPSJ4bXAuaWlkOjZDNDJBNEI1QjVCRDExRThCQjM0REIwQkZGMEQxODY0IiB4bXA6Q3JlYXRvclRvb2w9IkFkb2JlIFBob3Rvc2hvcCBDUzQgV2luZG93cyI+IDx4bXBNTTpEZXJpdmVkRnJvbSBzdFJlZjppbnN0YW5jZUlEPSIzREVENkU1N0FDREVDNEJBNzkxNUM2M0NCN0RENzM0NyIgc3RSZWY6ZG9jdW1lbnRJRD0iM0RFRDZFNTdBQ0RFQzRCQTc5MTVDNjNDQjdERDczNDciLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz7/7gAOQWRvYmUAZMAAAAAB/9sAhAABAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEB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" style="width: 70px;"/>
											<br/>
											<br/>
											<font align="center">e-FATURA</font>
										</span>
									</span>
								</span>
							</td>
							<td style="width: 242px; text-align: center;">
								<img alt="" src="data:image/jpeg;base64,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" style="width: 200px; height: 162px;"/>
							</td>
						</tr>
						<tr>
							<td style="width: 205px;"> </td>
							<td style="width: 200px;"> </td>
							<td style="width: 242px;"> </td>
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
										<xsl:if test="//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA'">
											<tr>
												<td align="left" style="width: 469px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">Pasaport No:<xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Person/cac:IdentityDocumentReference/cbc:ID"/>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<xsl:if test="//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA'">
											<tr>
												<td align="left" style="width: 469px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">Ülkesi<xsl:call-template name="Country">
																	<xsl:with-param name="CountryType">
																		<xsl:value-of select="//n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:Person/cbc:NationalityID"/>
																	</xsl:with-param>
																</xsl:call-template>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
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
																	<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cac:PostalAddress/cac:Country/cbc:Name"/>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cac:PostalAddress/cac:Country/cbc:Name"/>
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
																	<xsl:if test="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cbc:WebsiteURI !=''">
																		<xsl:text>Web Sitesi : </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:AccountingCustomerParty/cac:Party/cbc:WebsiteURI"/>
																	</xsl:if>
																</xsl:when>
																<xsl:otherwise>
																	<xsl:if test="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cbc:WebsiteURI !=''">
																		<xsl:text>Web Sitesi : </xsl:text>
																		<xsl:value-of select="n1:Invoice/cac:BuyerCustomerParty/cac:Party/cbc:WebsiteURI"/>
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
									</tbody>
								</table>
							</td>
							<td style="width: 200px;"> </td>
							<td style="width: 242px;">
								<table style="width: 242px; border-collapse: collapse;">
									<tbody>
										<tr>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold; white-space: pre;">Özelleştirme No:</span>
														</span>
													</span>
												</span>
											</td>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:value-of select="n1:Invoice/cbc:CustomizationID"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Senaryo:</span>
														</span>
													</span>
												</span>
											</td>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:value-of select="n1:Invoice/cbc:ProfileID"/>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<tr>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Fatura Tipi:</span>
														</span>
													</span>
												</span>
											</td>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
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
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Fatura </span>
															<span style="font-weight: bold;">No:</span>
														</span>
													</span>
												</span>
											</td>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
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
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
												<span style="font-size: 10px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-family: verdana,geneva,sans-serif;">
															<span style="font-weight: bold;">Fatura Tarihi:</span>
														</span>
													</span>
												</span>
											</td>
											<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
												<span style="color: rgb(105, 105, 105);">
													<span style="font-size: 10px;">
														<span style="font-family: verdana,geneva,sans-serif;">
															<xsl:for-each select="//n1:Invoice">
																<xsl:for-each select="cbc:IssueDate">
																	<xsl:value-of select="substring(.,9,2)"/>-<xsl:value-of select="substring(.,6,2)"/>-<xsl:value-of select="substring(.,1,4)"/>
																</xsl:for-each>
															</xsl:for-each>
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:value-of select="n1:Invoice/cbc:IssueTime"/>
															</span>
														</span>
													</span>
												</span>
											</td>
										</tr>
										<xsl:if test="//n1:Invoice/cac:DespatchDocumentReference">
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<strong>İrsaliye No:</strong>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
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
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<strong>İrsaliye Tarihi:</strong>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
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
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<strong style="color: rgb(105, 105, 105); font-family: verdana, geneva, sans-serif; font-size: 10px;">Sipariş No:</strong>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
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
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<strong style="color: rgb(105, 105, 105); font-family: verdana, geneva, sans-serif; font-size: 10px;">Sipariş Tarihi:</strong>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
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
										<xsl:if test="//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA'">
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<strong style="color: rgb(105, 105, 105); font-family: verdana, geneva, sans-serif; font-size: 10px;">Aracı Kurum VKN:</strong>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:value-of select="n1:Invoice/cac:TaxRepresentativeParty/cac:PartyIdentification/cbc:ID[@schemeID = 'ARACIKURUMVKN']"/>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<xsl:if test="//n1:Invoice/cbc:ProfileID = 'YOLCUBERABERFATURA'">
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<strong style="color: rgb(105, 105, 105); font-family: verdana, geneva, sans-serif; font-size: 10px;">Aracı Kurum Unvan:</strong>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 129px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:TaxRepresentativeParty">
																	<xsl:value-of select="cac:PartyName/cbc:Name"/>
																	<br/>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
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
							<td style="width: 200px;"> </td>
							<td style="width: 242px;"> </td>
						</tr>
						<xsl:if test="//n1:Invoice/cbc:InvoiceTypeCode = 'SGK'">
							<tr>
								<td style="width: 205px;">
									<table align="left" border="0" cellpadding="0" cellspacing="0" width="350">
										<tbody>
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold; white-space: pre;">Sağlık Fatura Tipi</span>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 189px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:value-of select="//n1:Invoice/cbc:AccountingCost"/>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Mükellef Kodu:</span>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 189px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																	<xsl:if test="cbc:DocumentTypeCode= 'MUKELLEF_KODU'">
																		<xsl:value-of select="cbc:DocumentType"/>
																	</xsl:if>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Mükellef Adı:</span>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 189px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																	<xsl:if test="cbc:DocumentTypeCode= 'MUKELLEF_ADI'">
																		<xsl:value-of select="cbc:DocumentType"/>
																	</xsl:if>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Dosya No:</span>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 189px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:for-each select="//n1:Invoice/cac:AdditionalDocumentReference">
																	<xsl:if test="cbc:DocumentTypeCode= 'DOSYA_NO' or cbc:DocumentTypeCode= 'HARCAMA_REFERANS_NO' ">
																		<xsl:value-of select="cbc:DocumentType"/>
																	</xsl:if>
																</xsl:for-each>
															</span>
														</span>
													</span>
												</td>
											</tr>
											<tr>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none;">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Dönem:</span>
															</span>
														</span>
													</span>
												</td>
												<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 189px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:value-of select="//n1:Invoice/cac:InvoicePeriod/cbc:StartDate"/>
																<xsl:text>/ </xsl:text>
																<xsl:value-of select="//n1:Invoice/cac:InvoicePeriod/cbc:EndDate"/>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
								<td style="width: 200px;"> </td>
								<td style="width: 242px;"> </td>
							</tr>
						</xsl:if>
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
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:ManufacturersItemIdentification/cbc:ID">
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10%;text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Barkod</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cbc:Name">
								<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 15%;text-align: center;">
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
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cbc:Note">
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
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 8%; text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Miktar</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10%; text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Birim Fiyat</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 5%;text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">İskonto Oranı</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 5%;text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">İskonto Tutarı</span>
										</span>
									</strong>
								</span>
							</td>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 6%; text-align: center;">
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
							<xsl:if test="//n1:Invoice/cbc:ProfileID != 'IHRACAT'">
								<td condition="//n1:Invoice/cbc:ProfileID != 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 4%;text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Diğer Vergiler</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
								<span style="font-size: 9px;">
									<strong>
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">Malzeme / Hizmet Tutarı</span>
										</span>
									</strong>
								</span>
							</td>
							<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
								<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Teslim Şartı</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
								<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Eşya Kap Cinsi</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
								<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Kap No</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
								<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Kap Adet</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
								<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Teslim / Bedel Ödeme Yeri</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
								<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Gönderim Şekli</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
								<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">GTİP İhracat</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode/@listName='GTIP'">
								<td condition="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode/@listName='GTIP'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">GTİP Kamu</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode/@listName='CPA'">
								<td condition="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode/@listName='CPA'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">CPA</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
							<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:OriginCountry/cbc:Name">
								<td condition="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:OriginCountry/cbc:Name" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: center;">
									<span style="font-size: 9px;">
										<strong>
											<span style="color: rgb(105, 105, 105);">
												<span style="font-family: verdana,geneva,sans-serif;">Menşei</span>
											</span>
										</strong>
									</span>
								</td>
							</xsl:if>
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
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:SellersItemIdentification/cbc:ID">
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10%; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:choose>
														<xsl:when test="./cac:Item/cac:SellersItemIdentification/cbc:ID != ''">
															<xsl:value-of select="./cac:Item/cac:SellersItemIdentification"/>
														</xsl:when>
													</xsl:choose>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:ManufacturersItemIdentification/cbc:ID">
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10%; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:choose>
														<xsl:when test="./cac:Item/cac:ManufacturersItemIdentification/cbc:ID != ''">
															<xsl:value-of select="./cac:Item/cac:ManufacturersItemIdentification"/>
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
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cbc:Name">
									<td style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 6%; text-align: center;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Item/cbc:Name"/>
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
								<xsl:if test="//n1:Invoice/cbc:ProfileID != 'IHRACAT'">
									<td condition="//n1:Invoice/cbc:ProfileID != 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 4%; text-align: right;">
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
								</xsl:if>
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
								<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
									<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Delivery/cac:DeliveryTerms/cbc:ID[@schemeID='INCOTERMS']"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
									<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:PackagingTypeCode"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
									<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:ID"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
									<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Delivery/cac:Shipment/cac:TransportHandlingUnit/cac:ActualPackage/cbc:Quantity"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
									<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Delivery/cac:DeliveryAddress"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
									<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:call-template name="TransportMode">
														<xsl:with-param name="TransportModeType">
															<xsl:value-of select="./cac:Delivery/cac:Shipment/cac:ShipmentStage/cbc:TransportModeCode"/>
														</xsl:with-param>
													</xsl:call-template>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT'">
									<td condition="//n1:Invoice/cbc:ProfileID = 'IHRACAT'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:Delivery/cac:Shipment/cac:GoodsItem/cbc:RequiredCustomsID"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode/@listName='GTIP'">
									<td condition="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode/@listName='GTIP'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:for-each select="./cac:InvoiceLine/cac:Item/cac:CommodityClassification[cbc:ItemClassificationCode/@listName = 'GTİP']">
														<xsl:value-of select="cbc:ItemClassificationCode"/>
													</xsl:for-each>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode/@listName='CPA'">
									<td condition="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:CommodityClassification/cbc:ItemClassificationCode/@listName='CPA'" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:for-each select="./cac:InvoiceLine/cac:Item/cac:CommodityClassification[cbc:ItemClassificationCode/@listName = 'CPA']">
														<xsl:value-of select="cbc:ItemClassificationCode"/>
													</xsl:for-each>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
								<xsl:if test="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:OriginCountry/cbc:Name">
									<td condition="//n1:Invoice/cac:InvoiceLine/cac:Item/cac:OriginCountry/cbc:Name" style="border: 0.05em solid rgb(132, 132, 132); border-image: none; width: 10.6%; text-align: right;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-size: 10px;">
												<span style="font-family: verdana,geneva,sans-serif;">
													<xsl:value-of select="./cac:InvoiceLine/cac:Item/cac:OriginCountry/cbc:Name"/>
												</span>
											</span>
										</span>
									</td>
								</xsl:if>
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
										<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT' and //n1:Invoice/cac:AllowanceCharge and //n1:Invoice/cac:AllowanceCharge/cbc:ChargeIndicator = 'true' and //n1:Invoice/cac:AllowanceCharge/cbc:AllowanceChargeReason = 'Navlun'">
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Navlun</span>
															</span>
														</span>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:choose>
																	<xsl:when test="//n1:Invoice/cac:AllowanceCharge and //n1:Invoice/cac:AllowanceCharge/cbc:ChargeIndicator = 'true'">
																		<xsl:for-each select="//n1:Invoice/cac:AllowanceCharge">
																			<xsl:if test="cbc:AllowanceChargeReason = 'Navlun'">
																				<xsl:value-of select="format-number(cbc:Amount, '###.##0,00', 'european')"/>
																				<xsl:if test="cbc:Amount/@currencyID">
																					<xsl:text/>
																					<xsl:if test="cbc:Amount/@currencyID = 'TRY'">
																						<xsl:text> TL </xsl:text>
																					</xsl:if>
																					<xsl:if test="cbc:Amount/@currencyID != 'TRY'">
																						<xsl:value-of select="cbc:Amount/@currencyID"/>
																					</xsl:if>
																				</xsl:if>
																			</xsl:if>
																		</xsl:for-each>
																	</xsl:when>
																</xsl:choose>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
										<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT' and //n1:Invoice/cac:AllowanceCharge and //n1:Invoice/cac:AllowanceCharge/cbc:ChargeIndicator = 'true' and //n1:Invoice/cac:AllowanceCharge/cbc:AllowanceChargeReason = 'Sigorta'">
											<tr align="right" id="budgetContainerTr">
												<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
													<span style="font-size: 10px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-family: verdana,geneva,sans-serif;">
																<span style="font-weight: bold;">Sigorta</span>
															</span>
														</span>
													</span>
												</td>
												<td align="right" id="lineTableBudgetTd" style="width: 120px;">
													<span style="color: rgb(105, 105, 105);">
														<span style="font-size: 10px;">
															<span style="font-family: verdana,geneva,sans-serif;">
																<xsl:choose>
																	<xsl:when test="//n1:Invoice/cac:AllowanceCharge and //n1:Invoice/cac:AllowanceCharge/cbc:ChargeIndicator = 'true'">
																		<xsl:for-each select="//n1:Invoice/cac:AllowanceCharge">
																			<xsl:if test="cbc:AllowanceChargeReason = 'Sigorta'">
																				<xsl:value-of select="format-number(cbc:Amount, '###.##0,00', 'european')"/>
																				<xsl:if test="cbc:Amount/@currencyID">
																					<xsl:text/>
																					<xsl:if test="cbc:Amount/@currencyID = 'TRY'">
																						<xsl:text> TL </xsl:text>
																					</xsl:if>
																					<xsl:if test="cbc:Amount/@currencyID != 'TRY'">
																						<xsl:value-of select="cbc:Amount/@currencyID"/>
																					</xsl:if>
																				</xsl:if>
																			</xsl:if>
																		</xsl:for-each>
																	</xsl:when>
																</xsl:choose>
															</span>
														</span>
													</span>
												</td>
											</tr>
										</xsl:if>
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
											<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT' and //n1:Invoice/cac:AllowanceCharge and //n1:Invoice/cac:AllowanceCharge/cbc:ChargeIndicator = 'true' and //n1:Invoice/cac:AllowanceCharge/cbc:AllowanceChargeReason = 'Navlun'">
												<tr align="right" id="budgetContainerTr">
													<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
														<span style="font-size: 10px;">
															<span style="color: rgb(105, 105, 105);">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<span style="font-weight: bold;">Navlun</span>
																</span>
															</span>
														</span>
													</td>
													<td align="right" id="lineTableBudgetTd" style="width: 120px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-size: 10px;">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<xsl:choose>
																		<xsl:when test="//n1:Invoice/cac:AllowanceCharge and //n1:Invoice/cac:AllowanceCharge/cbc:ChargeIndicator = 'true'">
																			<xsl:for-each select="//n1:Invoice/cac:AllowanceCharge">
																				<xsl:if test="cbc:AllowanceChargeReason = 'Navlun'">
																					<xsl:value-of select="format-number(cbc:Amount * ../cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')"/>
																					<xsl:text> TL </xsl:text>
																				</xsl:if>
																			</xsl:for-each>
																		</xsl:when>
																	</xsl:choose>
																</span>
															</span>
														</span>
													</td>
												</tr>
											</xsl:if>
											<xsl:if test="//n1:Invoice/cbc:ProfileID = 'IHRACAT' and //n1:Invoice/cac:AllowanceCharge and //n1:Invoice/cac:AllowanceCharge/cbc:ChargeIndicator = 'true' and //n1:Invoice/cac:AllowanceCharge/cbc:AllowanceChargeReason = 'Sigorta'">
												<tr align="right" id="budgetContainerTr">
													<td align="right" id="lineTableBudgetTd" style="width: 319px;" width="200">
														<span style="font-size: 10px;">
															<span style="color: rgb(105, 105, 105);">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<span style="font-weight: bold;">Sigorta</span>
																</span>
															</span>
														</span>
													</td>
													<td align="right" id="lineTableBudgetTd" style="width: 120px;">
														<span style="color: rgb(105, 105, 105);">
															<span style="font-size: 10px;">
																<span style="font-family: verdana,geneva,sans-serif;">
																	<xsl:choose>
																		<xsl:when test="//n1:Invoice/cac:AllowanceCharge and //n1:Invoice/cac:AllowanceCharge/cbc:ChargeIndicator = 'true'">
																			<xsl:for-each select="//n1:Invoice/cac:AllowanceCharge">
																				<xsl:if test="cbc:AllowanceChargeReason = 'Sigorta'">
																					<xsl:value-of select="format-number(cbc:Amount * ../cac:PricingExchangeRate/cbc:CalculationRate, '###.##0,00', 'european')"/>
																					<xsl:text> TL </xsl:text>
																				</xsl:if>
																			</xsl:for-each>
																		</xsl:when>
																	</xsl:choose>
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
												<span style="font-family: verdana,geneva,sans-serif;">Fi�� Saati</span>
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
				<table border="1" cellpadding="0" cellspacing="0" style="width: 800px;">
					<tbody>
						<tr>
							<td>
								<p style="margin-left: 40px;">
									<br/>
									<span style="font-size: 10px;">
										<span style="color: rgb(105, 105, 105);">
											<span style="font-family: verdana,geneva,sans-serif;">
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
												<xsl:if test="(//n1:Invoice/cbc:ProfileID = 'EARSIVFATURA')">
													<br/>
													<b>
														<span style="color:red;">
															<xsl:text>e-Arşiv faturalarınızı elektronik ortamda görüntülemek ve indirilebilmek için "</xsl:text>
															<a target="_blank" href="https://faturasorgulama.elogo.com.tr">
																<xsl:text>https://faturasorgulama.elogo.com.tr</xsl:text>
															</a>
															<xsl:text>" platformunu kullanabilirsiniz.</xsl:text>
														</span>
													</b>
												</xsl:if>​</span>
										</span>
									</span>
								</p>
							</td>
						</tr>
					</tbody>
				</table>
				<table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
					<tbody>
						<tr>
							<td>
								<xsl:if test="not(//n1:Invoice/cac:DespatchDocumentReference)">
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
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Converters
Imports Newtonsoft.Json.Serialization
'Imports System.Runtime.Serialization

Namespace Json

    Public Class DataJson
        <JsonProperty("order_id")>
        Public Property OrderId As String = ""
        <JsonProperty("generation")>
        Public Property Generation As Integer
        <JsonProperty("documents")>
        Public Property Documents As List(Of Document) = New List(Of Document)
        <JsonProperty("members")>
        Public Property Members As List(Of Member) = New List(Of Member)
        <JsonProperty("contract")>
        Public Property Contract As Contract = Nothing
        <JsonProperty("supply")>
        Public Property Supply As Supply = New Supply
        <JsonProperty("goods")>
        Public Property Goods As List(Of Good)
    End Class

    Public Class Document
        <JsonProperty("doc_id")>
        Public Property DocId As Integer
        <JsonProperty("doc_class")>
        Public Property DocClass As String = Nothing
        <JsonProperty("mode_code")>
        Public Property ModeCode As String = Nothing
        <JsonProperty("document_mode_id")>
        Public Property DocumentModeId As String = Nothing
        <JsonProperty("file_name")>
        Public Property FileName As String = Nothing
        <JsonProperty("name")>
        Public Property DocumentName As String = Nothing
        <JsonProperty("number")>
        Public Property DocumentNumber As String = Nothing
        <JsonProperty("doc_date")>
        Public Property DocumentDate As Date?
        <JsonProperty("url")>
        Public Property Url As String = Nothing
    End Class

    Public Class Member
        <JsonProperty("roles")>
        Public Property Roles As List(Of Role) = New List(Of Role)
        <JsonProperty("type_member")>
        Public Property MemberType As String = Nothing
        <JsonProperty("name_from_doc")>
        Public Property NameFromDoc As String = Nothing
        <JsonProperty("name_long")>
        Public Property NameLong As String = Nothing
        <JsonProperty("name_short")>
        Public Property NameShort As String = Nothing
        <JsonProperty("inn")>
        Public Property Inn As String = Nothing
        <JsonProperty("kpp")>
        Public Property Kpp As String = Nothing
        <JsonProperty("ogrn")>
        Public Property Ogrn As String = Nothing
        <JsonProperty("address")>
        Public Property Address As Address = Nothing
        <JsonProperty("passport")>
        Public Property Passport As Passport = Nothing
        <JsonProperty("phone")>
        Public Property Phone As String = Nothing
        <JsonProperty("email")>
        Public Property Email As String = Nothing
        <JsonProperty("bank")>
        Public Property Bank As Bank = Nothing
        <JsonProperty("restrictions")>
        Public Property Restrictions As List(Of Restriction) = New List(Of Restriction)
    End Class

    <JsonConverter(GetType(StringEnumConverter))>
    Public Enum Role
        seller
        buyer
        sender
        recipient
        carrier
        consumer
    End Enum

    Public Class Address
        <JsonProperty("full")>
        Public Property Full As String = Nothing
        <JsonProperty("postal_code")>
        Public Property PostalCode As String = Nothing
        <JsonProperty("country")>
        Public Property Country As Country = Nothing
        <JsonProperty("region")>
        Public Property Region As String = Nothing
        <JsonProperty("city")>
        Public Property City As String = Nothing
        <JsonProperty("street")>
        Public Property Street As String = Nothing
        <JsonProperty("home")>
        Public Property Home As String = Nothing
    End Class

    Public Class Country
        <JsonProperty("code_alpha2")>
        Public Property CodeAlpha2 As String = Nothing
        <JsonProperty("name_short")>
        Public Property NameShort As String = Nothing
    End Class

    Public Class Passport
        <JsonProperty("identity_card_code")>
        Public Property IdentityCardCode As String = Nothing
        <JsonProperty("identity_card_name")>
        Public Property IdentityCardName As String = Nothing
        <JsonProperty("identity_card_series")>
        Public Property IdentityCardSeries As String = Nothing
        <JsonProperty("identity_card_number")>
        Public Property IdentityCardNumber As String = Nothing
        <JsonProperty("identity_card_date")>
        Public Property IdentityCardDate As Date = Nothing
        <JsonProperty("organization_name")>
        Public Property OrganizationName As String = Nothing
    End Class

    Public Class Bank
        <JsonProperty("address")>
        Public Property Address As Address
    End Class

    Public Class Contract
        <JsonProperty("documents")>
        Public Property Documents As List(Of Document) = New List(Of Document)
        <JsonProperty("term")>
        Public Property Term As Date? = Nothing
        <JsonProperty("contract_text")>
        Public Property Text As String = Nothing
    End Class

    Public Class Supply
        <JsonProperty("documents")>
        Public Property Documents As List(Of Document) = New List(Of Document)
        <JsonProperty("destination_country")>
        Public Property DestinationCountry As Country = Nothing
        <JsonProperty("sender_country")>
        Public Property SenderCountry As Country = Nothing
        <JsonProperty("direction")>
        Public Property Direction As String = Nothing
        <JsonProperty("origin_country")>
        Public Property OriginCountry As Country = Nothing
        <JsonProperty("trading_country")>
        Public Property TradingCountry As Country = Nothing
        <JsonProperty("bank_country")>
        Public Property BankCountry As Country = Nothing
        <JsonProperty("delivery_terms")>
        Public Property DeliveryTerms As Incoterms = Nothing
    End Class

    Public Class Incoterms
        <JsonProperty("delivery_place")>
        Public Property DeliveryPlace As String = Nothing
        <JsonProperty("delivery_terms_string_code")>
        Public Property DeliveryTermsStringCode As String = Nothing
    End Class

    Public Class Good
        <JsonProperty("doc_id")>
        Public Property DocId As Integer
        <JsonProperty("name_from_doc")>
        Public Property NameFromDoc As String = Nothing
        <JsonProperty("name_con")>
        Public Property NameCon As String = Nothing
        <JsonProperty("name_dec")>
        Public Property NameDec As String = Nothing
        <JsonProperty("description")>
        Public Property Description As String = Nothing
        <JsonProperty("tnved")>
        Public Property Tnved As String = Nothing
        <JsonProperty("goods_quantity")>
        Public Property GoodsQuantity As String = Nothing
        <JsonProperty("measure_unit_qualifier_name")>
        Public Property MeasureUnitQualifierName As String = Nothing
        <JsonProperty("gross_weight_quantity")>
        Public Property GrossWeightQuantity As String = Nothing
        <JsonProperty("packing_quantity")>
        Public Property PackingQuantity As String = Nothing
        <JsonProperty("price")>
        Public Property Price As String = Nothing
        <JsonProperty("total_cost")>
        Public Property TotalCost As String = Nothing
        <JsonProperty("currency_code")>
        Public Property CurrencyCode As String = Nothing
        <JsonProperty("restrictions")>
        Public Property Restrictions As List(Of Restriction) = New List(Of Restriction)

    End Class

    Public Class Restriction
        <JsonProperty("db_id")>
        Public Property DbId As Integer = 0
        <JsonProperty("doc_is_law")>
        Public Property DocIsLaw As Boolean = False
        <JsonProperty("doc_caption")>
        Public Property DocCaption As String = String.Empty
        <JsonProperty("doc_section")>
        Public Property DocSection As String
        <JsonProperty("doc_position")>
        Public Property DocPosition As String
        <JsonProperty("doc_description")>
        Public Property DocDescription As String
        <JsonProperty("object_description")>
        Public Property ObjectDescription As String
        <JsonProperty("object_is_equal")>
        Public Property ObjectIsEqual As Boolean = False
    End Class

    ' ВХОДЯЩИЕ ДОКУМЕНТЫ ИЗ VLM

    Public Class IncomingDocument
        <JsonProperty("doc_id")>
        Public Property DocId As Integer
        <JsonProperty("title")>
        Public Property Title As String = Nothing
        <JsonProperty("file_name")>
        Public Property FileName As String = Nothing
        <JsonProperty("markdown")>
        Public Property Markdown As String = Nothing
    End Class

    Public Class IncomingDocList
        <JsonProperty("documents")>
        Public Property Documents As List(Of IncomingDocument) = New List(Of IncomingDocument)
    End Class

End Namespace
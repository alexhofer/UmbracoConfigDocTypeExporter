# Umbraco Config Doc Type Exporter

---

## Overview
---
This is a lightweight exporter created to quickly export published items from the Umbraco.config file to CSV format. It does **not** use or include any Umbraco files or use any Umbraco API functionality. It allows you to exclude or include different properties, or filter by a specific property value if needed. 

If there are properties on a document type that contain a reference to another node in the Umbraco config the exporter will attempt to get the value from that related node. If you do not wish to use that functionality please exclude the node that contains that related node ID.

This was tested and used with Umbraco 6.X and 7.X - there may be updates in the future to the way Umbraco saves items to the Umbraco config file and may cause the exporter to not function. 


## How It Works
---

#### Options

Below are the different options you can use and some examples.

1. 'u', "umbracoConfig" 
	- **Required**
	- The Umbraco Config file being used for export. [Error Code: 1 if document cannot be loaded.]

2. 'd', "documentType",
	- **Required**
	- The Umbraco Document Type to export. All properties will be exported.

3. 's', "siteName"
	- **Required**
	- The name of the site the Umbraco config is for.

4. 'o', "outputFolder"
	- **Required**
	- The folder where the output will be saved.

5. 'p', "propertiesToInclude"
	- Not Required
	- Specifies properties to export, if empty it will export all properties. Ex. -p hotdog notHotdog

6. 'x', "propertiesToExclude"
	- Not Required
	- Specifies properties to exclude from export, if empty it will export all properties. Ex. -p notHotdog hotdog

7. 'f', "filterByProperty"
	- Not Required
	- Filters by a specific property for the document type. Only one filter is supported at this time. Ex. -f productSize:large

#### Error Codes
1. Error Code: 0 
	- Not actually an error, just exited successfully. 

2. Error Code: 1
	- Document Load Error, I.E. something is wrong with the Umbraco Config file and it couldn't be loaded.

3. Error Code: 2 
	- Incorrect Options. The Options could not be parsed for some reason. Missing space, misspelled, option doesn't exist, etc...

#### Example Arguments

``` -u C:\Projects\UmbracoConfigDocTypeExporter\UmbracoConfig\umbraco.config -d article -s MySite -o C:\Projects\UmbracoConfigDocTypeExporter\Exports\MySite\ ```

The above arguments will look for an Umbraco Config in the following location:

* C:\Projects\UmbracoConfigDocTypeExporter\UmbracoConfig\umbraco.config

It will export out the **"article"** document type.

With the Site Name of **"MySite"**.

To the following folder:
* C:\Projects\UmbracoConfigDocTypeExporter\Exports\MySite\

The file name will be: **MySite_Article.csv**


### Future Work
---

#### Features
1. Ability to export to other file types. (I.E. JSON, XML)
2. Ability to filter by more than one property value.


### Pull Requests
---
If you see this and want to add anything, fix a bug, or make any changes feel free to make a pull request. Or create an issue and I can look into it. 

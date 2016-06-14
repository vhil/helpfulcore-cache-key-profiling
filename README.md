### Helpfulcore - helpful features for Sitecore
# Helpfulcore CacheKeyProfiling

This module allows you to debug and profile your Sitecore rendering cache keys that were generated to render your page.
In order to use the module, please install this nuget package to your Sitecore website project:
```
Install-Package Helpfulcore.CacheKeyProfiling
```

You will be able to see something like this at your source code:
```html
<!-- Site name: website -->
<!-- Database: web -->
<!-- Language: da -->

<!-- Cache Key list: -->
<!-- controller::Seo#Metadata_#lang:DA_#area:Seo_#data:/sitecore/content/sites/website/Home_#parm:_#qs:  -->
<!-- view::/Views/Layouts/_Partials/Stylesheets.cshtml_#lang:DA  -->
<!-- view::/Views/Layouts/_Partials/Icons.cshtml_#lang:DA  -->
<!-- view::/Views/Layouts/_Partials/Fonts.cshtml_#lang:DA  -->
<!-- view::/Views/Layouts/_Partials/HeadExtras.cshtml_#lang:DA  -->
<!-- view::/Views/Layouts/_Partials/BrowserUpgrade.cshtml_#lang:DA  -->
<!-- view::/Views/Layouts/_Partials/GlobalCookieMessage.cshtml_#lang:DA  -->
<!-- view::/Views/Layouts/_Partials/SiteLogos.cshtml_#lang:DA  -->
<!-- controller::Navigation#MainNavigation_#lang:DA_#area:Navigation_#data:/sitecore/content/sites/website/Home_#login:True_#parm:_#qs:  -->
<!-- controller::Navigation#MainSideNavigation_#lang:DA_#area:Navigation_#data:/sitecore/content/sites/website/Home_#login:True_#parm:_#qs:  -->
<!-- view::/Views/SimpleContent/Hero.cshtml_#lang:DA_#data:/sitecore/content/sites/website/website-content/heros/hero-test_#parm:_#qs:  -->
<!-- view::/Views/LiveFeeds/JackpotsNow.cshtml_#lang:DA_#data:/sitecore/content/sites/website/website-content/sidebar/website-jackpot-boxes/jackpotter-nu_#parm:_#qs:  -->
<!-- view::/Views/LiveFeeds/NewWinners.cshtml_#lang:DA_#data:/sitecore/content/sites/website/website-content/sidebar/website-winner-boxes/nye-vindere_#parm:_#qs:  -->
<!-- view::/Views/SimpleContent/BoxLink.cshtml_#lang:DA_#data:/sitecore/content/sites/website/website-content/sidebar/website-link-boxes/box-link-test_#parm:_#qs:  -->
<!-- controller::Games#GameList_#lang:DA_#area:Games_#data:/sitecore/content/sites/website/Home_#dev:Default#isMobile:False_#login:True_#parm:Hide Title=1&amp;Associated Tags={EA74A9BD-38C4-4012-80AE-95D443479470}|{2CCE6B9C-398A-457A-B86E-8F7D1B57B369}&amp;Page Size=17&amp;Hide Pagination=1&amp;Autocomplete Page Size=50_#qs:  -->
<!-- view::/Views/SimpleContent/BoxImage.cshtml_#lang:DA_#data:/sitecore/content/sites/website/website-content/sidebar/website-image-boxes/box-image-test-motiejus_#parm:_#qs:  -->
<!-- view::/Views/SimpleContent/BoxText.cshtml_#lang:DA_#data:/sitecore/content/sites/website/website-content/sidebar/website-text-boxes/box_#parm:_#qs:  -->
<!-- controller::Footer#Footer_#lang:DA_#area:Footer_#data:/sitecore/content/sites/website/Home_#parm:_#qs:  -->
<!-- view::/Views/Layouts/_Partials/BottomScripts.cshtml_#lang:DA  -->
```

This way you can see what cache keys are being generated during the renderRendering pipeline for each of rendering on your page.

Package contents:
- 	/bin/Helpfulcore.CacheKeyProfiling.dll
-	/App_Config/Include/Helpfulcore/Helpfulcore.CacheKeyProfiling.config
- 	/Views/Shared/CacheKeyProfiling/CacheKeys.cshtml

In the include config file Helpfulcore.CacheKeyProfiling.config there is an injection into <mvc.renderRendering> pipeline where generated cache keys are being saved into current request.
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <pipelines>
      <mvc.renderRendering>
        <processor type="Helpfulcore.CacheKeyProfiling.Pipelines.RenderRendering.GatherCacheKeys, Helpfulcore.CacheKeyProfiling" patch:before="*[@type='Sitecore.Mvc.Pipelines.Response.RenderRendering.RenderFromCache, Sitecore.Mvc']" />
      </mvc.renderRendering>
    </pipelines>
  </sitecore>
</configuration>
```

And then there is a view /Views/Shared/CacheKeyProfiling/CacheKeys.cshtml which reads previously saved collection and outputs it as HTML comments to the page.
And that's it!

In order to render it you will need to write one extra line of code on your layout file. Render it at the bottom of the page for convenience.
```cs
	@Html.RenderCacheKeys()
```
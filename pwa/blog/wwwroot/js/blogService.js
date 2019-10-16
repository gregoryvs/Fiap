define(['./template.js','../lib/showdown/showdown.js'], function (template, showdown) {
    
    var blogLatestPostsUrl = '/Home/LatestBlogPosts/';
    var blogPostUrl = '/Home/Post/?link=';
    var blogMorePostsUrl = '/Home/MoreBlogPosts/?oldestBlogPostId='; 
    var oldestBlogPostId = 0;

    function setOldestBlogPostId(data) {
        var ids = data.map(item => item.postId);
        oldestBlogPostId = Math.min(...ids);
    }

    // function loadLatestBlogPosts() {
    //     fetch(blogLatestPostsUrl)
    //         .then(function (response) {
    //             return response.json();
    //         }).then(function (data) {
    //             template.appendBlogList(data);
    //             setOldestBlogPostId(data);
    //         });
    // }

    // function loadMoreBlogPosts() {
    //         fetch(blogMorePostsUrl + oldestBlogPostId)
    //             .then(function (response) {
    //                 return response.json();
    //         }).then(function (data) { console.log(data); template.appendBlogList(data); setOldestBlogPostId(data);
    //     }); 
    // }

    function loadData(url) {
        fetch(url)
            .then(function (response) {
                return response.json();
            }).then(function (data) {
                console.log(data);
                template.appendBlogList(data);
                setOldestBlogPostId(data);
    }); }

    function loadLatestBlogPosts() {
        loadData(blogLatestPostsUrl);
    }
    function loadMoreBlogPosts() {
        loadData(blogMorePostsUrl + oldestBlogPostId);
    }

    function loadBlogPost(link) {
        debugger;
        fetch(blogPostUrl + link)
            .then(function (response) {
                return response.text();
            }).then(function (data) {
                var converter = new showdown.Converter();
                html = converter.makeHtml(data);
                template.showBlogItem(html, link);
                window.location = '#' + link;
    }); }
    return {
        loadLatestBlogPosts: loadLatestBlogPosts,
        loadBlogPost: loadBlogPost
    }
});
       
	
    <script  type="text/javascript">
    $(function () {
        var links = $('.sidebar-menu-links > a');
        links.on('click', function () {
            links.removeClass('selected');
            $(this).addClass('selected');
        });
    });
</script>

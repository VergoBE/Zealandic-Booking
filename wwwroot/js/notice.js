/*

    Name: NoticeHandler
    Purpose: Handle all notices for the site.
    Author: @marcusmaczewski - https://github.com/marcusmaczewski
    Version: 1.0.0

    Built for: Layback Digital

*/


class NoticeHandler {

    
    constructor() {

        /* CHECK IF JQUERY IS LOADED - IF NOT, RETURN ERROR
        ----------------------------------------------------------------------------------- */

        try {
            if (typeof jQuery == 'undefined') {
                // jQuery IS NOT loaded, do stuff here.
                throw new Error('jQuery is not loaded - Jquery is required for this class');
            }
        } catch (error) {
            throw error;
        }

    }
    
    showNotice(icon, text, time = 5000) {



        /* INIT THE NOTICE DIV WITH THE CONTENT
        ----------------------------------------------------------------------------------- */

        let $noticeList = jQuery('.notice_wrapper .notice_list');

        switch (icon) {
            case false:
                icon = false;    
            break;
            case 'success':
                icon = '<i class="fas fa-check-circle"></i>';
            break;
            case 'error':
                icon = '<i class="fas fa-exclamation-circle"></i>';
            break;
            case 'info':
                icon = '<i class="fas fa-info-circle"></i>';
            break;
            case 'warning':
                icon = '<i class="fas fa-exclamation-triangle"></i>';
            break;
            default:
                icon = '<i class="fas fa-info-circle"></i>';
            break;
        }

        let $icon = `<div class="icon">
                        ${icon}
                    </div>`;

        let $shtml = `
            <div class="notice">
                <div class="inner">
                    ${$icon}
                    <div class="text">
                        ${text}
                    </div>
                </div>
            </div>
        `;

        let $oHtml = jQuery($shtml);
        let timer = null;


        /* TRY AND DISPLAY THE NOTICE - IF FAILS, RETURNS ERROR
        ----------------------------------------------------------------------------------- */

        try {

            if(!text) throw new Error('No text provided');
            if(!$oHtml) throw new Error('No html provided');

            // Check how many notices are in the list, if more than 10, remove the first one
            if($noticeList.children().length > 8)
            {
                $noticeList.children().first().remove();
            }

            // Append the notice to the notice list
            $noticeList.append($oHtml);    
    
            // Wait for 100ms before sliding the notice in
            setTimeout(() => {
                slideIn();
            }, 100);
            

            // After xxxx ms, the notice will be removed
            timer = setTimeout(() => {
                slideOut();
            }, time);


            // On hover, pause the timer
            $oHtml.on('mouseenter', function() {
                clearTimeout(timer);
            });

            // When mouse leaves, resume the timer
            $oHtml.on('mouseleave', function() {
                slideOut();
            });


        } catch (error) {
            throw error;
        }

        /* SLIDE THE NOTICE INTO THE LIST
        ----------------------------------------------------------------------------------- */

        function slideIn() {
            $oHtml.css({
                'opacity': 1,
                'transform': 'translateX(0%)',
                'transition': 'all 0.5s ease-in-out',
            });
        }


        /* SLIDE THE NOTICE OUT FROM THE LIST TO THEN BE REMOVED
        ----------------------------------------------------------------------------------- */

        function slideOut(){
            $oHtml.css({
                'opacity': 0,
                'transform': 'translateX(100%)',
                'transition': 'all 0.5s ease-in-out',
            });

            setTimeout(() => {
                $oHtml.remove();
            }, time + 600);
        }
        
    }

}
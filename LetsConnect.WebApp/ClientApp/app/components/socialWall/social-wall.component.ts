
import { Global } from '../../Shared/global';
import { Component, OnInit } from '@angular/core';
import { Angular2SocialLoginModule, AuthService } from "angular2-social-login";
//import * as $ from 'jquery';
declare var $: JQuery;

declare global {
    interface JQuery {
        (selector: string): JQuery;
        dcSocialStream(options:any): JQuery;
    }
}
@Component({
    templateUrl: './social-wall.component.html'
})

export class SocialWallComponent implements OnInit {
    
    constructor(public _auth: AuthService) {
        
    }
    
    
    ngOnInit() {
        
        this.socialWall();
    }

    socialWall() {
        
            $('#social-stream').dcSocialStream({
                feeds: {
                    twitter: {
                        id: '/9927875,#designchemical,designchemical'
                    },
                    rss: {
                        id: 'http://feeds.feedburner.com/DesignChemical,http://feeds.feedburner.com/codecondo'
                    },
                    stumbleupon: {
                        id: 'remix4'
                    },
                    facebook: {
                        id: '157969574262873,Facebook Timeline/376995711728',
                        out: 'intro,thumb,text,user,share'
                    },
                    google: {
                        id: '113657921371822642352'
                    },
                    delicious: {
                        id: 'designchemical'
                    },
                    vimeo: {
                        id: 'brad'
                    },
                    youtube: {
                        id: 'FilmTrailerZone/UUPPPrnT5080hPMxK1N4QSjA',
                        thumb: 'medium',
                        out: 'intro,thumb,title,user,share'
                    },
                    pinterest: {
                        id: 'jaffrey,designchemical/design-ideas'
                    },
                    flickr: {
                        id: ''
                    },
                    lastfm: {
                        id: 'lastfm'
                    },
                    //dribbble: {
                    //    id: 'frogandcode'
                    //},
                    deviantart: {
                        id: 'isacg'
                    },
                    tumblr: {
                        id: 'richters',
                        thumb: 250
                    }
                },
                rotate: {
                    delay: 0
                },
                twitterId: 'designchemical',
                control: false,
                filter: true,
                wall: true,
                center: true,
                cache: false,
                max: 'limit',
                limit: 5,
                iconPath: '../../../../../wwwroot/SocialWall/images/dcsns-dark/',
                imagePath: '../../../../../wwwroot/SocialWall/images/dcsns-dark/'
            });
        
    }
}

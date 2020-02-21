import { Global } from '../../Shared/global';
import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { HomeService } from '../../Service/home.service';
import { Observable } from 'rxjs/Rx';

declare var $: JQuery;

declare global {
    interface JQuery {
        (selector: string): JQuery;
        dcSocialStream(options: any): JQuery;
    }
}

@Component({
    templateUrl: './home.component.html'
    
})

export class HomeComponent implements OnInit {

    private hubConnection: signalR.HubConnection;
    nick: string = '';
    message:string = '';
    messages: string[] = [];

    constructor(private _homeService: HomeService) { }
     
    ngOnInit() {

        this.socialWall();
        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("/LetsConnectHub")
            .build(); 
        
        this.hubConnection
            .start()
            .then(() => {
                console.log('Connection started!');    
                console.log(Global.BASE_HOME_ENDPOINT);

            })
            .catch(err => console.log('Error while establishing connection :(', err));
        
        this.hubConnection.on("ReceiveMessage", (sender, message) => {
            this.messages.push(message);
        });
        
    }

     sendMessage(): void {
       
         this._homeService.get(Global.BASE_HOME_ENDPOINT + '/SendMessage?msg='+this.message).subscribe(
            data => {
                if (data != "") //Success
                {
                    this.message = "";
                }
                else {
                    
                }
                
            },
            error => {
                
            }
        );
    }

    socialWall() {
        $('#social-stream').dcSocialStream({
            feeds: {
                twitter: {
                    id: 'designchemical'
                },
                rss: {
                    id: 'http://feeds.feedburner.com/DesignChemical'
                },
                stumbleupon: {
                    id: 'designchemical'
                },
                facebook: {
                    id: '157969574262873,Facebook Timeline/376995711728'
                },
                google: {
                    id: '113657921371822642352',
                    api_key: 'AIzaSyDFfGr_sX_wRrI832w-pKI1PFvBzfSH0Xc'
                },
                delicious: {
                    id: 'designchemical'
                },
                vimeo: {
                    id: 'brad'
                },
                youtube: {
                    id: 'PLNqbsyklU9tH802qk4lQ8oNOwmO7CUh2h',
                    thumb: '0'
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
                dribbble: {
                    id: 'frogandcode'
                },
                deviantart: {
                    id: 'isacg'
                },
                tumblr: {
                    id: 'richters',
                    thumb: 250
                }
            },
            twitterId: 'designchemical',
            iconPath: 'images/dcsns-dark/',
            imagePath: 'images/dcsns-dark/'
        });

    }

}

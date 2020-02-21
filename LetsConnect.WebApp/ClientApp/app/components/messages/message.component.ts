import { Global } from '../../Shared/global';
import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { HomeService } from '../../Service/home.service';
import { Observable } from 'rxjs/Rx';


@Component({
    templateUrl: './message.component.html'
})

export class MessageComponent implements OnInit {

    private hubConnection: signalR.HubConnection;
    name: string = '';
    message: string = 'hello';
    messages: string[] = [];

    constructor(private _homeService: HomeService) { }

    ngOnInit() {

        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("/LetsConnectHub")
            .build();

        this.hubConnection
            .start()
            .then(() => {
                console.log('Connection started!');
                console.log(Global.BASE_HOME_ENDPOINT);

                this.hubConnection.invoke('getConnectionId')
                    .then(function (connectionId) {
                        // Send the connectionId to controller
                        console.log("connectionID: " + connectionId);
                        $("#signalRconnectionId").attr("value", connectionId);
                    });
            })
            .catch(err => console.log('Error while establishing connection :(', err));

        //this.hubConnection.on("ReceiveMessage", (sender, message)=>{            
        //    this.messages.push(message);
        //});

        this.hubConnection.on('sendToAll', (name: string, receivedMessage: string) => {
            const text = `${name}: ${receivedMessage}`;
            this.messages.push(text);
        });

    }
    public sendMessage(): void {
        this.hubConnection
            .invoke('sendToAll', localStorage.getItem('name'), this.message)
            .catch(err => console.error(err));
    }
}

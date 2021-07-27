import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '@auth0/auth0-angular';
import { catchError, mergeMap } from 'rxjs/operators';

@Injectable()
export class Auth0Interceptor implements HttpInterceptor {
    constructor(private _auth: AuthService) {
    }

    intercept(
        req: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        return this._auth.getAccessTokenSilently().pipe(
            mergeMap(token => {
                const tokenReq = req.clone({
                    setHeaders: { Authorization: `Bearer ${token}` }
                });
                return next.handle(tokenReq);
            }),
            catchError((error) => {
                console.log(error);
                return next.handle(req);
            })
        );
    }
}

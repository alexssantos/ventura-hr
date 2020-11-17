import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable()
export class TokenInterceptorService implements HttpInterceptor {
	
	// We inject a LoginService
	constructor() {}

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		
		const token = sessionStorage.getItem('token_access');

		let newHeaders = req.headers;
		if (token) {
			// If we have a token, we append it to our new headers
			newHeaders = newHeaders.append('Content-Type', 'application/json')
									.append('Authorization', `Bearer ${token}`);		
		}
		
		const authReq = req.clone({ headers: newHeaders });		
		return next.handle(authReq);
	}
}
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MyConfig } from '../../my-config';
import { MyBaseEndpointAsync } from '../../helper/my-base-endpoint-async.interface';
import {MyPagedRequest} from '../../helper/my-paged-request';
import {StudentUpdateOrInsertRequest} from './student-update-or-insert-endpoint.service';



export interface StudentDeleteRequest {
  id: number;
  deletedById?: number;
}

@Injectable({
  providedIn: 'root'
})

export class StudentDeleteEndpointService implements MyBaseEndpointAsync<StudentDeleteRequest, void> {
  private apiUrl = `${MyConfig.api_address}/students`;

  constructor(private httpClient: HttpClient) {}

  handleAsync(request: StudentDeleteRequest) {
    return this.httpClient.delete<void>(this.apiUrl, {
    body:request

});
  }
}

//handleAsync(request: StudentUpdateOrInsertRequest) {
//  return this.httpClient.post<number>(this.apiUrl, request);
//}

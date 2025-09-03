import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {MyConfig} from '../../my-config';
import {MyBaseEndpointAsync} from '../../helper/my-base-endpoint-async.interface';

export interface AcademicYearAllResponse {
  id: number;
  name: string;
}

@Injectable({
  providedIn: 'root'
})
export class AcademicYearAllEndpoint implements MyBaseEndpointAsync<void, AcademicYearAllResponse[]> {
  private apiUrl = `${MyConfig.api_address}/academicYears/all`;

  constructor(private httpClient: HttpClient) {
  }

  handleAsync() {
    return this.httpClient.get<AcademicYearAllResponse[]>(`${this.apiUrl}`);
  }
}

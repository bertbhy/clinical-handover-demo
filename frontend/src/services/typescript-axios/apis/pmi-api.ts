/* tslint:disable */
/* eslint-disable */
/**
 * My Title
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import globalAxios, { AxiosResponse, AxiosInstance, AxiosRequestConfig } from 'axios';
import { Configuration } from '../configuration';
// Some imports not used depending on template conditions
// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS, RequestArgs, BaseAPI, RequiredError } from '../base';
import { GetWardPatient } from '../models';
import { GridQueryResponseOfGetWardPatient } from '../models';
/**
 * PmiApi - axios parameter creator
 * @export
 */
export const PmiApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @param {string} [patientKey] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        pmiGetPatient: async (patientKey?: string, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/api/Pmi/patient`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            if (patientKey !== undefined) {
                localVarQueryParameter['patientKey'] = patientKey;
            }

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @param {string} [specialtyCode] 
         * @param {string} [sortdatafield] 
         * @param {string} [sortorder] 
         * @param {number} [pagesize] 
         * @param {number} [pagenum] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        pmiQueryPatient: async (specialtyCode?: string, sortdatafield?: string, sortorder?: string, pagesize?: number, pagenum?: number, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/api/Pmi/QueryPatient`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            if (specialtyCode !== undefined) {
                localVarQueryParameter['specialtyCode'] = specialtyCode;
            }

            if (sortdatafield !== undefined) {
                localVarQueryParameter['sortdatafield'] = sortdatafield;
            }

            if (sortorder !== undefined) {
                localVarQueryParameter['sortorder'] = sortorder;
            }

            if (pagesize !== undefined) {
                localVarQueryParameter['pagesize'] = pagesize;
            }

            if (pagenum !== undefined) {
                localVarQueryParameter['pagenum'] = pagenum;
            }

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
    }
};

/**
 * PmiApi - functional programming interface
 * @export
 */
export const PmiApiFp = function(configuration?: Configuration) {
    return {
        /**
         * 
         * @param {string} [patientKey] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pmiGetPatient(patientKey?: string, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<GetWardPatient>>> {
            const localVarAxiosArgs = await PmiApiAxiosParamCreator(configuration).pmiGetPatient(patientKey, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @param {string} [specialtyCode] 
         * @param {string} [sortdatafield] 
         * @param {string} [sortorder] 
         * @param {number} [pagesize] 
         * @param {number} [pagenum] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pmiQueryPatient(specialtyCode?: string, sortdatafield?: string, sortorder?: string, pagesize?: number, pagenum?: number, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<GridQueryResponseOfGetWardPatient>>> {
            const localVarAxiosArgs = await PmiApiAxiosParamCreator(configuration).pmiQueryPatient(specialtyCode, sortdatafield, sortorder, pagesize, pagenum, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
    }
};

/**
 * PmiApi - factory interface
 * @export
 */
export const PmiApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    return {
        /**
         * 
         * @param {string} [patientKey] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pmiGetPatient(patientKey?: string, options?: AxiosRequestConfig): Promise<AxiosResponse<GetWardPatient>> {
            return PmiApiFp(configuration).pmiGetPatient(patientKey, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @param {string} [specialtyCode] 
         * @param {string} [sortdatafield] 
         * @param {string} [sortorder] 
         * @param {number} [pagesize] 
         * @param {number} [pagenum] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async pmiQueryPatient(specialtyCode?: string, sortdatafield?: string, sortorder?: string, pagesize?: number, pagenum?: number, options?: AxiosRequestConfig): Promise<AxiosResponse<GridQueryResponseOfGetWardPatient>> {
            return PmiApiFp(configuration).pmiQueryPatient(specialtyCode, sortdatafield, sortorder, pagesize, pagenum, options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * PmiApi - object-oriented interface
 * @export
 * @class PmiApi
 * @extends {BaseAPI}
 */
export class PmiApi extends BaseAPI {
    /**
     * 
     * @param {string} [patientKey] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof PmiApi
     */
    public async pmiGetPatient(patientKey?: string, options?: AxiosRequestConfig) : Promise<AxiosResponse<GetWardPatient>> {
        return PmiApiFp(this.configuration).pmiGetPatient(patientKey, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @param {string} [specialtyCode] 
     * @param {string} [sortdatafield] 
     * @param {string} [sortorder] 
     * @param {number} [pagesize] 
     * @param {number} [pagenum] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof PmiApi
     */
    public async pmiQueryPatient(specialtyCode?: string, sortdatafield?: string, sortorder?: string, pagesize?: number, pagenum?: number, options?: AxiosRequestConfig) : Promise<AxiosResponse<GridQueryResponseOfGetWardPatient>> {
        return PmiApiFp(this.configuration).pmiQueryPatient(specialtyCode, sortdatafield, sortorder, pagesize, pagenum, options).then((request) => request(this.axios, this.basePath));
    }
}
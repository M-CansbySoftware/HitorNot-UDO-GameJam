using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Mustafa
{
    public class MatematikselHesaplamalar
    {
        public void carpma(int Gelensayi, List<GameObject> Karakterler, Transform pozisyon, List<GameObject> OlusmaEfektler)
        {
            int DonguSayisi = (GameManage.anlikkaraktersayisi * Gelensayi) - GameManage.anlikkaraktersayisi;
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < DonguSayisi)
                {
                    if (!item.activeInHierarchy)
                    {
                        foreach (var item2 in OlusmaEfektler)
                        {
                            if (!item2.activeInHierarchy)
                            {

                                item2.SetActive(true);
                                item2.transform.position = pozisyon.position;

                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();

                                break;


                            }
                        }



                        item.transform.position = pozisyon.position;
                        item.SetActive(true);
                        sayi++;

                    }
                }
                else
                {
                    sayi = 0;
                    break;
                }

            }
            GameManage.anlikkaraktersayisi *= Gelensayi;
        }
        public void toplama(int Gelensayi, List<GameObject> Karakterler, Transform pozisyon, List<GameObject> OlusmaEfektler)
        {
            int sayi2 = 0;
            foreach (var item in Karakterler)
            {
                if (sayi2 < Gelensayi)
                {
                    if (!item.activeInHierarchy)
                    {

                        foreach (var item2 in OlusmaEfektler)
                        {
                            if (!item2.activeInHierarchy)
                            {

                                item2.SetActive(true);
                                item2.transform.position = pozisyon.position;

                                item2.GetComponent<ParticleSystem>().Play();

                                item2.GetComponent<AudioSource>().Play();
                                break;


                            }
                        }
                        item.transform.position = pozisyon.position;
                        item.SetActive(true);
                        sayi2++;

                    }
                }
                else
                {
                    sayi2 = 0;
                    break;
                }

            }
            GameManage.anlikkaraktersayisi += Gelensayi;
        }
        public void cikartma(int Gelensayi, List<GameObject> Karakterler, List<GameObject> KaybolmaEfektler)
        {
            if (GameManage.anlikkaraktersayisi < Gelensayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in KaybolmaEfektler)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yenipoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = yenipoz;

                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();

                            break;


                        }
                    }



                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManage.anlikkaraktersayisi = 1;
            }
            else
            {
                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != Gelensayi)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in KaybolmaEfektler)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yenipoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = yenipoz;

                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();

                                    break;


                                }
                            }


                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;

                        }
                    }
                    else
                    {
                        sayi3 = 0;
                        break;
                    }

                }
                GameManage.anlikkaraktersayisi -= Gelensayi;
            }


        }

        public void bolme(int Gelensayi, List<GameObject> Karakterler, List<GameObject> KaybolmaEfektler)
        {
            if (GameManage.anlikkaraktersayisi <= Gelensayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in KaybolmaEfektler)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yenipoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = yenipoz;

                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();

                            break;


                        }
                    }

                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManage.anlikkaraktersayisi = 1;
            }
            else
            {
                int bolen = GameManage.anlikkaraktersayisi / Gelensayi;
                int sayi4 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi4 != bolen)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in KaybolmaEfektler)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yenipoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                                    item2.SetActive(true);
                                    item2.transform.position = yenipoz;

                                    item2.GetComponent<ParticleSystem>().Play();

                                    item2.GetComponent<AudioSource>().Play();
                                    break;


                                }
                            }



                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi4++;

                        }
                    }
                    else
                    {
                        sayi4 = 0;
                        break;
                    }

                }
                if (GameManage.anlikkaraktersayisi % Gelensayi == 0)
                {
                    GameManage.anlikkaraktersayisi /= Gelensayi;
                }
                else if (GameManage.anlikkaraktersayisi % Gelensayi == 1)
                {
                    GameManage.anlikkaraktersayisi = (GameManage.anlikkaraktersayisi / Gelensayi) + 1;
                }
                else if (GameManage.anlikkaraktersayisi % Gelensayi == 2)
                {
                    GameManage.anlikkaraktersayisi = (GameManage.anlikkaraktersayisi / Gelensayi) + 2;
                }
            }


        }
    }

    public class MemoryManage
        {
        public void DataSave_String(string Key,string Value)
        {
            PlayerPrefs.SetString(Key, Value);
            PlayerPrefs.Save();

        }
        public void DataSave_int(string Key, int Value)
        {
            PlayerPrefs.SetInt(Key, Value);
            PlayerPrefs.Save();
        }
        public void DataSave_Float(string Key, float Value)
        {
            PlayerPrefs.SetFloat(Key, Value);
            PlayerPrefs.Save();
        }

        public string DataRead_String(string Key)
        {
            return PlayerPrefs.GetString(Key);
        }
        public int DataRead_int(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }
        public float DataRead_Float(string Key)
        {
            return PlayerPrefs.GetFloat(Key);
        }

        public void ControlnDefinition()
        {
            if (!PlayerPrefs.HasKey("LastLevel"))
            {
                PlayerPrefs.SetInt("LastLevel", 1); //sayi sahnenin indexi
                PlayerPrefs.SetFloat("MenuMusic", 1);
                PlayerPrefs.SetFloat("MenuFx", 1);
                PlayerPrefs.SetFloat("GameMusic", 1);
            }
        }

    }

}

